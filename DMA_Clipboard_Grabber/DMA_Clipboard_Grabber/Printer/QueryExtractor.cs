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
        /// Resulting querry assembled at construction time.
        /// </summary

        private string query;

        public string Query
        {
            get { return query; }
            private set { query = value; }
        }


        public QueryExtractor(String[] input, DMAEnvironment type)
        {
            this.CodesList = input;
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
            this.Query = assembleQuerry(this.CodesList, this.Environment);
        }
    }
}
