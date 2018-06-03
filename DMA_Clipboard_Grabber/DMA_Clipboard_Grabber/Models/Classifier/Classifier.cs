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
        public List<string> ZoneMatches { get; private set; }
        public List<string> ProductMatches { get; private set; }

        public List<string> InputStringSplitted { get; private set; }
        #endregion

        #region Constructor
        public Classifier(string input)
        {
            InputStringSplitted = input.Split(delimiters.ToArray<char>()).ToList<string>();
            
            DefinitnMatches = RegexMatches(InputStringSplitted, regexDEFINITN);
            DefinitnMatches = DefinitnMatches.Distinct().ToList();

            DesignMatches = RegexMatches(InputStringSplitted, regexDESIGN);
            DesignMatches = DesignMatches.Distinct().ToList();

            CommerceMatches = RegexMatches(InputStringSplitted, regexCOMMERCE);
            CommerceMatches = CommerceMatches.Distinct().ToList();

            // Fake classifications - the same code as DEFINITN
            FolderMatches = DefinitnMatches;
            FolderMatches = FolderMatches.Distinct().ToList();

            ZoneMatches = DefinitnMatches;
            ZoneMatches = ZoneMatches.Distinct().ToList();

            ProductMatches = DefinitnMatches;
            ProductMatches = ProductMatches.Distinct().ToList();
        }
        #endregion

        #region REGEX and delimiters definition
        // Regex patterns to compare against grouped per criterion
        List<string> regexDEFINITN = new List<string>
        {
            @"^\w{2}\*\d{3,10}\z",   // DEFINITN:   AT*962
            @"^\w{2}[0]\*\d{3,9}\z",// DEFINITN:   AT0*312
            @"^\w{2}[0]\d{10}\z"        // DEFINITN:   AT00001233962
        };

        List<string> regexDESIGN = new List<string>
        {
            @"^\w{2}[Dd]\*\d{3,9}\z", // DESIGN:     ATD*3962
            @"^\w{2}[Dd]\d{10}\z"        // DESIGN:     ATD0001233962
        };

        List<string> regexCOMMERCE = new List<string>
        {
            @"^DTR\*\d{3,9}\z",     // COMMERCE:    DTR*123
            @"^DTR\d{10}\z",            // COMMERCE:    DTR0001233962
            @"^dtr\*\d{3,9}\z",     // COMMERCE:    dtr*123
            @"^dtr\d{10}\z"             // COMMERCE:    dtr0001233962
        };

        // Delimiters matrix to identify characters that might be appended at the end of any number.
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
