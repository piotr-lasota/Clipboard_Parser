using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMA_Clipboard_Grabber
{
    public static class ZeroFiller
    {
        public static string fillToDigits(string code, int digits, char desiredFill)
        {
            // if the code is already at it's desired length, return it back switching it to capital letters.
            if(code.Length == digits)
            {
                return code.ToUpper();
            }

            // if the code exceeds it's desired length, throw a FormatException
            if(code.Length >= digits)
            {
                throw new FormatException("Code is longer than expected. Truncating is not supported");
            }

            // Upperchar the string and fill it with the desired character in place of the asterisk.
            return code.ToUpper().Replace("*", new string(desiredFill, (digits - code.Length + 1)));
        }
    }
}
