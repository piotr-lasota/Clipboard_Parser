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
        /// <summary>
        /// Array of codes that are to be assembled into a query
        /// </summary>
        public String[] CodesList { get; private set; }

        /// <summary>
        /// Environment string based on the selected DMA environment
        /// </summary>
        public string Environment { get; private set; }

        /// <summary>
        /// Query assembled on get() time.
        /// </summary>
        public string Query { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="input">Input codes vector</param>
        /// <param name="type">Type enum</param>
        public QueryExtractor(String[] input, DMAEnvironment type)
        {
            CodesList = input;
            switch(type)
            {
                case DMAEnvironment.COMMERCE:
                    Environment = "COMMERCE";
                    break;
                case DMAEnvironment.DEFINITN:
                    Environment = "DEFINITN";
                    break;
                case DMAEnvironment.DESIGN:
                    Environment = "DESIGN";
                    break;
                case DMAEnvironment.FOLDER:
                    Environment = "FOLDER";
                    break;
            }
            Query = assembleQuerry();
        }

        private string assembleQuerry()
        {
            //TODO: Query assembly xD
            return String.Join("\nOR\n", CodesList);
        }
    }
}
