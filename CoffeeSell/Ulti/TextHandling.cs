using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSell.Ulti
{
    internal class TextHandling
    {
        public static string CustomDecimalToString(decimal x)
        {
            // If the number has no fractional part, return as integer string
            if (x % 1 == 0)
                return ((int)x).ToString();

            // Else, return full decimal
            return x.ToString();
        }
        public static string CustomDecimalToString(string input)
        {
            if (decimal.TryParse(input, out decimal parsed))
            {
                return CustomDecimalToString(parsed); // Reuse decimal version
            }
            return input; // Return original if not a valid decimal
        }
        public static bool IsValidNumericInput(char keyChar, string currentText)
        {
            // Allow control characters (Backspace, Delete, etc.)
            if (char.IsControl(keyChar))
                return true;

            // Allow digits
            if (char.IsDigit(keyChar))
                return true;

            // Allow one dot if not already present
            if (keyChar == '.' && !currentText.Contains('.'))
                return true;

            // Otherwise, block
            return false;
        }
        public static bool IsValidAlphabeticInput(char keyChar, string currentText)
        {
            // Allow control characters (Backspace, Delete, etc.)
            if (char.IsControl(keyChar))
                return true;

            // Allow alphabetic characters (both uppercase and lowercase)
            if (char.IsLetter(keyChar))
                return true;

            // Block space
            if (keyChar == ' ')
                return false;

            // Otherwise, block
            return false;
        }
    }
}
