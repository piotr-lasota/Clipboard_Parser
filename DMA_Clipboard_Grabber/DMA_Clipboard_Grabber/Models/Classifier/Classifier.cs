using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DMA_Clipboard_Grabber
{
    public class Classifier
    {
        #region Fields and properties
        public List<string> DefinitnMatches { get; private set; }
        public List<string> DesignMatches { get; private set; }
        public List<string> CommerceMatches { get; private set; }
        public List<string> FolderMatches { get; private set; }

        public List<string> InputStringSplitted { get; private set; }
        #endregion

        #region Constructor
        public Classifier(string input)
        {
            InputStringSplitted = input.Split(this.delimiters.ToArray<char>()).ToList<string>();
            
            this.DefinitnMatches = RegexMatches(this.InputStringSplitted, this.regexDEFINITN);
            DefinitnMatches = DefinitnMatches.Distinct().ToList();

            this.DesignMatches = RegexMatches(this.InputStringSplitted, this.regexDESIGN);
            DesignMatches = DesignMatches.Distinct().ToList();

            this.CommerceMatches = RegexMatches(this.InputStringSplitted, this.regexCOMMERCE);
            CommerceMatches = CommerceMatches.Distinct().ToList();

            this.FolderMatches = this.DefinitnMatches;
            FolderMatches = FolderMatches.Distinct().ToList();
        }
        #endregion

        #region REGEX and delimiters definition
        // Regex patterns to compare against grouped per criterion
        List<string> regexDEFINITN = new List<string>
        {
            @"^\w{2}\*\d{1,}\d{2}\z",   // DEFINITN:   AT*962
            @"^\w{2}[0]\*\d{1,}\d{2}\z",// DEFINITN:   AT0*312
            @"^\w{2}[0]\d{10}\z"        // DEFINITN:   AT00001233962
        };

        List<string> regexDESIGN = new List<string>
        {
            @"^\w{2}[Dd]\*\d{1,}\d{2}\z", // DESIGN:     ATD*3962
            @"^\w{2}[Dd]\d{10}\z"        // DESIGN:     ATD0001233962
        };

        List<string> regexCOMMERCE = new List<string>
        {
            @"^DTR\*\d{1,}\d{2}\z",     // COMMERCE:    DTR*123
            @"^DTR\d{10}\z",            // COMMERCE:    DTR0001233962
            @"^dtr\*\d{1,}\d{2}\z",     // COMMERCE:    dtr*123
            @"^dtr\d{10}\z"             // COMMERCE:    dtr0001233962
        };

        // Delimiters matrix to identify characters that might be appended at the end of the number.
        List<char> delimiters = new List<char>
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
        private List<string> RegexMatches(List<string> inputs, List<string> patterns)
        {
            var partMatches = inputs.Where(inputElement => patterns.Any(pattern => Regex.IsMatch(inputElement, pattern)));

            return partMatches.ToList<string>();
        }
        #endregion
    }
}
