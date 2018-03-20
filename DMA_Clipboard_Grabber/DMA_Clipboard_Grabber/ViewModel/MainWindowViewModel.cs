using System;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace DMA_Clipboard_Grabber
{
    /// <summary>
    /// Main Window ViewModel - links the DMAClassifierModel with the GUI shown values
    /// (for quantities of objects identified in the clipboardd)
    /// 
    /// Additionally it launches the required QueryAssembler to prepare the string to be printed
    /// and keep it in the memory to be finally outputted in the location selected by the user.
    /// </summary>
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        #region Fields
        /// <summary>
        /// Stored DMACLassifierModel instance, that will be used by the app.
        /// </summary>
        DMAClassifierModel Classifier;
        #endregion

        #region Counters properties
        public string DefinitinCount { get; set; }
        public string DesignCount { get; set; }
        public string CommerceCount { get; set; }
        public string FolderCount { get; set; }
        #endregion

        #region Buttons enabler properties
        public string AnyDefinitn { get { return (Classifier.DefinitnMatches.Count() > 0).ToString(); }}
        public string AnyDesign{ get { return (Classifier.DesignMatches.Count() > 0).ToString(); } }
        public string AnyCommerce { get { return (Classifier.CommerceMatches.Count() > 0).ToString(); } }
        public string AnyFolder { get { return (Classifier.FolderMatches.Count() > 0).ToString(); } }
        #endregion

        #region Constructor
        public MainWindowViewModel()
        {
            Classifier = new DMAClassifierModel(System.Windows.Clipboard.GetText());
            DefinitinCount = Classifier.DefinitnMatches.Count().ToString();
            DesignCount = Classifier.DesignMatches.Count().ToString();
            CommerceCount = Classifier.CommerceMatches.Count().ToString();
            FolderCount = Classifier.FolderMatches.Count().ToString();
        }
        #endregion

        #region Commands        
        /// <summary>
        /// Saves the selected matches as DMA Filter query
        /// </summary>
        /// <param name="group">Array of part codes</param>
        /// <param name="selectedEnvironment">Selected DMA environment type</param>
        public static void SaveSelected(string[] group, DMAEnvironment selectedEnvironment)
        {
            Microsoft.Win32.SaveFileDialog SaveDialog = new Microsoft.Win32.SaveFileDialog();
            SaveDialog.FileName = "Query";
            SaveDialog.DefaultExt = ".qry";

            Nullable<bool> result = SaveDialog.ShowDialog();
            if (result == true)
            {
                QueryAssembler Printer = new QueryAssembler(group, selectedEnvironment);
                File.WriteAllText(SaveDialog.FileName, Printer.Query);
            }
        }
        #endregion

    }
}
