using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMA_Clipboard_Grabber
{
    /// <summary>
    /// Main Window ViewModel - links the DMAClassifierModel with the GUI shown values
    /// (for quantities of objects identified in the clipboardd)
    /// 
    /// Additionally it launches the required QueryExtractor to prepare the string to be printed
    /// and keep it in the memory to be finally outputted in the location selected by the user.
    /// </summary>
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Stored DMACLassifierModel instance, that will be used by the app.
        /// </summary>
        DMAClassifierModel Classifier;
        public string DefinitinCount { get; set; }

        public MainWindowViewModel()
        {
            
        }
    }
}
