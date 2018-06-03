using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using DMA_Clipboard_Grabber.Helpers;

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
        private const int CODE_LENGTH = 13;
        private const char FILLER_CHAR = '0';
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        #region Fields
        Classifier classifier;
        QueryAssembler queryAssembler;
        QueryPrinter queryPrinter;
        #endregion

        #region Command Properties
        public RelayCommand DefinitnExport { get; private set; }
        public RelayCommand FolderExport { get; private set; }
        public RelayCommand ZoneExport { get; private set; }
        public RelayCommand ProductExport { get; private set; }

        public RelayCommand DesignExport { get; private set; }

        public RelayCommand CommerceExport { get; private set; }
        #endregion

        #region Counters properties
        public string DefinitinCount { get { return classifier.DefinitnMatches.Count().ToString(); ; } }
        public string ZoneCount { get { return classifier.ZoneMatches.Count().ToString(); ; } }
        public string ProductCount { get { return classifier.ProductMatches.Count().ToString(); ; } }
        public string FolderCount { get { return classifier.FolderMatches.Count().ToString(); ; } }

        public string DesignCount { get { return classifier.DesignMatches.Count().ToString(); ; } }

        public string CommerceCount { get { return classifier.CommerceMatches.Count().ToString(); ; } }
        #endregion

        #region Buttons enabler properties
        public string AnyDefinitn { get { return (classifier.DefinitnMatches.Count() > 0).ToString(); }}
        public string AnyZone { get { return (classifier.ZoneMatches.Count() > 0).ToString(); } }
        public string AnyProduct { get { return (classifier.ProductMatches.Count() > 0).ToString(); } }
        public string AnyFolder { get { return (classifier.FolderMatches.Count() > 0).ToString(); } }

        public string AnyDesign{ get { return (classifier.DesignMatches.Count() > 0).ToString(); } }

        public string AnyCommerce { get { return (classifier.CommerceMatches.Count() > 0).ToString(); } }
        #endregion

        #region Constructor
        public MainWindowViewModel()
        {
            classifier = new Classifier(System.Windows.Clipboard.GetText());
            DefinitnExport = new RelayCommand(ExportDefinitn);
            ProductExport = new RelayCommand(ExportProduct);
            ZoneExport = new RelayCommand(ExportZone);
            FolderExport = new RelayCommand(ExportFolder);
            DesignExport = new RelayCommand(ExportDesign);
            CommerceExport = new RelayCommand(ExportCommerce);
        }
        #endregion

        #region Commands
        public void ExportDefinitn(object content)
        {
            queryAssembler = new QueryAssembler(classifier.DefinitnMatches, DMAEnvironment.DEFINITN, CODE_LENGTH, FILLER_CHAR);
            queryPrinter = new QueryPrinter(queryAssembler.Query);
            queryPrinter.PrintToPointedLocation();
            queryAssembler = null;
            queryPrinter = null;
        }

        public void ExportFolder(object content)
        {
            queryAssembler = new QueryAssembler(classifier.FolderMatches, DMAEnvironment.FOLDER, CODE_LENGTH, FILLER_CHAR);
            queryPrinter = new QueryPrinter(queryAssembler.Query);
            queryPrinter.PrintToPointedLocation();
            queryAssembler = null;
            queryPrinter = null;
        }

        public void ExportProduct(object content)
        {
            queryAssembler = new QueryAssembler(classifier.ProductMatches, DMAEnvironment.PRODUCT, CODE_LENGTH, FILLER_CHAR);
            queryPrinter = new QueryPrinter(queryAssembler.Query);
            queryPrinter.PrintToPointedLocation();
            queryAssembler = null;
            queryPrinter = null;
        }

        public void ExportZone(object content)
        {
            queryAssembler = new QueryAssembler(classifier.ZoneMatches, DMAEnvironment.ZONE, CODE_LENGTH, FILLER_CHAR);
            queryPrinter = new QueryPrinter(queryAssembler.Query);
            queryPrinter.PrintToPointedLocation();
            queryAssembler = null;
            queryPrinter = null;
        }

        public void ExportDesign(object content)
        {
            queryAssembler = new QueryAssembler(classifier.DesignMatches, DMAEnvironment.DESIGN, CODE_LENGTH, FILLER_CHAR);
            queryPrinter = new QueryPrinter(queryAssembler.Query);
            queryPrinter.PrintToPointedLocation();
            queryAssembler = null;
            queryPrinter = null;
        }

        public void ExportCommerce(object content)
        {
            queryAssembler = new QueryAssembler(classifier.CommerceMatches, DMAEnvironment.COMMERCE, CODE_LENGTH, FILLER_CHAR);
            queryPrinter = new QueryPrinter(queryAssembler.Query);
            queryPrinter.PrintToPointedLocation();
            queryAssembler = null;
            queryPrinter = null;
        }
        #endregion

    }
}
