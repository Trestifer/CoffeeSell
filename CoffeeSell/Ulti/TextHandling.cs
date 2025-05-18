using System;
using System.Collections.Generic;
using System.Data;
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
                return true;

            // Otherwise, block
            return false;
        }
        public static bool IsNumberInput(char keyChar, string currentText, int maxLength=255)
        {
            // Allow control characters (Backspace, Delete, etc.)
            if (char.IsControl(keyChar))
                return true;

            // Allow digits if current text hasn't reached max length
            if (char.IsDigit(keyChar) && currentText.Length < maxLength)
                return true;

            return false;
        }

        public static string txtLimit(TextBox txt, int max)
        {
            string s = txt.Text;
            if (s.Length > max)
            {
                return s.Substring(0, max);
            }
            return s;
        }
        public static string InputRange(TextBox txt, decimal min = decimal.MinValue, decimal max = decimal.MaxValue)
        {
            try
            {
                // Evaluate simple math expression like "87-3"
                var expression = txt.Text;
                var value = Convert.ToDecimal(new DataTable().Compute(expression, null));

                // Clamp to min/max range
                if (value > max)
                    return max.ToString();
                else if (value < min)
                    return min.ToString();
                else
                    return value.ToString();
            }
            catch
            {
                return txt.Text;
            }
        }
    }
}
