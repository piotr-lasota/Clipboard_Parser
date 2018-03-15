using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DMA_Clipboard_Grabber.ViewModel.Commands
{
    class ExtractCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action<string[], DMAEnvironment> myAction;

        public ExtractCommand(Action<string[],DMAEnvironment> action)
        {
            myAction = action;
        }

        public bool CanExecute(object parameter) { return true; }

        public void Execute(object parameter)
        {
            myAction.Invoke(string[] arg1, DMAEnvironment arg2); //TODO: How to pass two parameters here? Read about ICommand
        }
    }
}
