using System;
using System.Collections.Generic;
using System.Linq;

namespace DMA_Clipboard_Grabber
{
    /// <summary>
    /// Simple helper class to pass the List(string) into and get the output Query file
    /// </summary>
    public class QueryAssembler
    {
        static string envLine = "#CDMA.CATCON.ReplaceMe.PART"; //TODO: Query first line - get the proper form

        public List<string> CodesList { get; private set; }

        public string Environment { get; private set; }

        public string Query { get; private set; }

        public QueryAssembler(List<string> input, DMAEnvironment environment, int length, char fill)
        {
            CodesList = StringFill.FillListToLength(input, length, fill);
            Environment = environment.ToString();
            Query = AssembleQuerry();   
        }

        private string AssembleQuerry()
        {
            string environmentLine = envLine.Replace("ReplaceMe", Environment);
            string partLines = "\r\nPART_LIST;S_PART_NUMBER;WITH;"
                + String.Join(";;\r\nPART_LIST;S_PART_NUMBER;WITH;", CodesList)
                + ";;" + ((CodesList.Count > 1) ? "\r\n" : "");
            string orsSection = string.Join("\r\n", Enumerable.Repeat("OR", (CodesList.Count-1)));

            return environmentLine + partLines + (CodesList.Count > 1 ? orsSection : "");
        }
    }
}
