using System;
using System.Collections.Generic;
using System.Linq;

namespace DMA_Clipboard_Grabber
{

    //TODO: SOLID'ify this. Open for extension, closed for modification. Look an ENUM up and dispatch the proper handler meeting an interface / abstract class.

    /// <summary>
    /// Simple helper class to pass the String[] into and get the output Query file
    /// </summary>
    public class QueryAssembly
    {

        static string envLine = "##DMATYPE cośtam ReplaceMe"; //TODO: Query first line - get the proper form

        /// <summary>
        /// Array of codes that are to be assembled into a query
        /// </summary>
        public List<string> CodesList { get; private set; }

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
        /// <param name="input">Array of codes to search</param>
        /// <param name="environment">Search Environment string</param>
        public QueryAssembly(List<string> input, String environment)
        {
            CodesList = input;
            Environment = environment;
            Query = AssembleQuerry();   
        }

        private string AssembleQuerry()
        {
            string environmentLine = envLine.Replace("ReplaceMe", Environment);
            return environmentLine + "\r\nPART_LIST;S_PART_NUMBER;WITH;"
                + String.Join(";;\r\nOR\r\nPART_LIST;S_PART_NUMBER;WITH;", CodesList)
                + ";;";
        }
    }
}
