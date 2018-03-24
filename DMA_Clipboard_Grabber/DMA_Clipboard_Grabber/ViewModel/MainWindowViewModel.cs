using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;

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
        Classifier classifier;
        #endregion

        #region Counters properties
        public string DefinitinCount { get; set; }
        public string DesignCount { get; set; }
        public string CommerceCount { get; set; }
        public string FolderCount { get; set; }
        #endregion

        #region Buttons enabler properties
        public string AnyDefinitn { get { return (classifier.DefinitnMatches.Count() > 0).ToString(); }}
        public string AnyDesign{ get { return (classifier.DesignMatches.Count() > 0).ToString(); } }
        public string AnyCommerce { get { return (classifier.CommerceMatches.Count() > 0).ToString(); } }
        public string AnyFolder { get { return (classifier.FolderMatches.Count() > 0).ToString(); } }
        #endregion

        #region Constructor
        public MainWindowViewModel()
        {
            classifier = new Classifier(System.Windows.Clipboard.GetText());
            DefinitinCount = classifier.DefinitnMatches.Count().ToString();
            DesignCount = classifier.DesignMatches.Count().ToString();
            CommerceCount = classifier.CommerceMatches.Count().ToString();
            FolderCount = classifier.FolderMatches.Count().ToString();
            MessageBox.Show(new QueryAssembler(classifier.DefinitnMatches, "DEFINITN").Query);
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



            //Nullable<bool> result = SaveDialog.ShowDialog();
            //if (result == true)
            //{
            //    QueryAssembler Printer = new QueryAssembler(group, selectedEnvironment); //TODO: Fix this shit
            //    File.WriteAllText(SaveDialog.FileName, Printer.Query);
            //}
        }
        #endregion

    }
}
