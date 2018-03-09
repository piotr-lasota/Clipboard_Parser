using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace DMA_Clipboard_Grabber
{
    class DMAClassifierModel
    {
        #region Fields and properties
        private int myVar;

        public string[] DefinitnMatches { get; private set; }
        public string[] DesignMatches { get; private set; }
        public string[] CommerceMatches { get; private set; }
        public string[] InputStringSplitted { get; private set; }

        public int DefinitinCount
        {
            get { return this.DefinitnMatches.Count(); }
        }

        public int DesignCount
        {
            get { return this.DesignMatches.Count(); }
        }

        public int CommerceCount
        {
            get { return this.CommerceMatches.Count(); }
        }


        #endregion

        #region Constructor
        public DMAClassifierModel(string input)
        {
            InputStringSplitted = input.Split(this.delimiters);

            this.DefinitnMatches = RegexMatches(this.InputStringSplitted, this.regexDEFINITN);
            this.DesignMatches = RegexMatches(this.InputStringSplitted, this.regexDESIGN);
            this.CommerceMatches = RegexMatches(this.InputStringSplitted, this.regexCOMMERCE);
        }
        #endregion

        #region REGEX and delimiters definition
        // Regex patterns to compare against grouped per criterion
        string[] regexDEFINITN =
        {
            @"^\w{2}\*\d{1,}\d{2}\z",   // DEFINITN:   AT*962
            @"^\w{2}[0]\*\d{1,}\d{2}\z",// DEFINITN:   AT0*312
            @"^\w{2}[0]\d{10}\z"        // DEFINITN:   AT00001233962
        };

        string[] regexDESIGN =
        {
            @"^\w{2}[Dd]*\d{1,}\d{2}\z", // DESIGN:     ATD*3962
            @"^\w{2}[Dd]\d{10}\z"        // DESIGN:     ATD0001233962
        };

        string[] regexCOMMERCE =
        {
            @"^DTR\*\d{1,}\d{2}\z",     // COMMERCE:    DTR*123
            @"^DTR\d{10}\z",            // COMMERCE:    DTR0001233962
            @"^dtr\*\d{1,}\d{2}\z",     // COMMERCE:    dtr*123
            @"^dtr\d{10}\z"             // COMMERCE:    dtr0001233962
        };

        // Delimiters matrix to identify characters that might be appended at the end of the number.
        Char[] delimiters =
        {
            ',',
            ' ',
            '.',
            '-',
            '\n',
            '\r'
        };
        #endregion

        #region Helper Functions
        private string[] RegexMatches(string[] inputs, string[] patterns)
        {
            var partMatches = inputs
                .Where(inputElement => patterns.Any(pattern => Regex.IsMatch(inputElement, pattern)));

            return partMatches.ToArray<string>();
        }
        #endregion
    }
}
