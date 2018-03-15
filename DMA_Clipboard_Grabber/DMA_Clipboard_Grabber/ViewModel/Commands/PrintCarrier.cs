using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMA_Clipboard_Grabber
{
    //TODO: If I find a better way - get rid of this!
    /// <summary>
    /// Helper class to carry the parameters in one object. But I don't like the idea
    /// </summary>
    class PrintCarrier
    {
        public DMAEnvironment Environment { get; }
        public string[] Codes { get; }

        public PrintCarrier(string[] codes, DMAEnvironment environment)
        {
            Codes = codes;
            Environment = environment;
        }
    }
}
