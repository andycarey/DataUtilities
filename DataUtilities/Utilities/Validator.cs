using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataUtilities
{
    public static class Validator
    {
        /// <summary>
        /// Extension method that wraps int and decimal TryParse calls, and just returns the boolean result of the checks, indicating if the string is a valid number.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool StringIsNumeric(this string value)
        {
            int _throwawayInt = 0;
            bool _success = false;

            // Check to see if it's a whole number.
            _success = Int32.TryParse(value, out _throwawayInt);

            if (!_success)
            {
                // If it's not a whole number, check to see if it's a decimal.
                decimal _throwawayDec = 0;
                _success = Decimal.TryParse(value, out _throwawayDec);
            }

            return _success;
        }

        /// <summary>
        /// Extension method that wraps an Boolean.TryParse call, and just returns the boolean result of the check, indicating if the string is a valid bool.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool StringIsBoolean(this string value)
        {
            bool _throwaway = false;
            return Boolean.TryParse(value, out _throwaway);
        }

        /// <summary>
        /// Extension method that wraps an DateTime.TryParse call, and just returns the boolean result of the check, indicating if the string is a valid DateTime.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool StringIsDateTime(this string value)
        {
            DateTime _throwaway = new DateTime(1900, 1, 1);
            return DateTime.TryParse(value, out _throwaway);
        }
    }
}
