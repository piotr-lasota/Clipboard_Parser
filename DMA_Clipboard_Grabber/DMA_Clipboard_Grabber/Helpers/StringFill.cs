using System;

namespace DMA_Clipboard_Grabber
{
    public static class StringFill
    {
        /// <summary>
        /// Replaces the asterisk in string with a given character enough times to match a desired length
        /// </summary>
        /// <param name="code">Input string</param>
        /// <param name="desiredLength">Desired length of the string</param>
        /// <param name="desiredFill">Character to fill up with</param>
        /// /// <returns></returns>
        public static string FillToLength(string code, int desiredLength, char desiredFill)
        {
            // if the code is already at it's desired length, return it back switching it to capital letters.
            if(code.Length == desiredLength)
            {
                return code.ToUpper();
            }

            // if the code exceeds it's desired length, throw a FormatException
            if(code.Length >= desiredLength)
            {
                throw new FormatException("Code is longer than expected. Truncating is not supported");
            }

            // Upperchar the string and fill it with the desired character in place of the asterisk.
            return code.ToUpper().Replace("*", new string(desiredFill, (desiredLength - code.Length + 1)));
        }
    }
}
