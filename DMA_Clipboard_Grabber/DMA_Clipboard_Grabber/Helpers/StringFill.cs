using System;
using System.Collections.Generic;

namespace DMA_Clipboard_Grabber
{
    public static class StringFill
    {
        /// <summary>
        /// Replaces the asterisk in string with a given character enough times to match a desired length
        /// </summary>
        /// <param name="code">Input string</param>
        /// <param name="length">Desired length of the string</param>
        /// <param name="fill">Character to fill up with</param>
        /// /// <returns></returns>
        public static string FillStringToLength(string code, int length, char fill)
        {
            // if the code is already at it's desired length, return it back switching it to capital letters.
            if(code.Length == length)
            {
                return code.ToUpper();
            }

            // if the code exceeds it's desired length, throw a FormatException
            if(code.Length > length)
            {
                throw new FormatException("Code is longer than expected. Truncating is not supported");
            }

            // Upperchar the string and fill it with the desired character in place of the asterisk.
            return code.ToUpper().Replace("*", new string(fill, (length - code.Length + 1)));
        }

        /// <summary>
        /// Replaces the asterisks in strings with a given character enough times to match a desired length for every string
        /// </summary>
        /// <param name="codes">Input strings</param>
        /// <param name="length">Desired length of the string</param>
        /// <param name="fill">Character to fill up with</param>
        /// <returns></returns>
        public static List<string> FillListToLength(List<string> codes, int length, char fill)
        {
            var results = new List<string>();
            foreach(string code in codes)
            {
                // Just uppercase if at desired length
                if (code.Length == length)
                {
                    results.Add(code.ToUpper());
                }

                // if the code exceeds it's desired length, throw a FormatException
                else if (code.Length > length)
                {
                    throw new FormatException("Code is longer than expected. Truncating is not supported");
                }

                // Upperchar the string and fill it with the desired character in place of the asterisk.
                else
                {
                    results.Add(code.ToUpper().Replace("*", new string(fill, (length - code.Length + 1))));
                }
            }

            return results;
        }
    }
}
