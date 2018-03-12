using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMA_Clipboard_Grabber
{
    /// <summary>
    /// Simple helper class to pass the String[] into and get the output Query file
    /// </summary>
    class QueryExtractor
    {
        public String[] CodesList { get; set; }

        public QueryExtractor(String[] input, DMAEnvironment type)
        {
            this.CodesList = input;
        }
    }
}
