using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataUtilities
{
    public static class Guid
    {
        #region Public methods
        /// <summary>
        /// Returns a new uppercase guid value with options to exclude numbers and dashes
        /// </summary>
        /// <param name="excludeNumbers"></param>
        /// <param name="excludeDashes"></param>
        /// <returns></returns>
        public static string GuidUppercase(bool excludeNumbers = false, bool excludeDashes = false)
        {
            string _guid = System.Guid.NewGuid().ToString();
            _guid = ApplyFilters(_guid, excludeNumbers, false, excludeDashes);

            return _guid.ToUpper();
        }

        /// <summary>
        /// Returns a new lowercase guid value with options to exclude numbers and dashes
        /// </summary>
        /// <param name="excludeNumbers"></param>
        /// <param name="excludeDashes"></param>
        /// <returns></returns>
        public static string GuidLowercase(bool excludeNumbers = false, bool excludeDashes = false)
        {
            string _guid = System.Guid.NewGuid().ToString();
            _guid = ApplyFilters(_guid, excludeNumbers, false, excludeDashes);

            return _guid;
        }

        /// <summary>
        /// Returns only numbers found in a new guid with option to exclude dashes
        /// </summary>
        /// <param name="excludeDashes"></param>
        /// <returns></returns>
        public static string GuidFilteredNumbers(bool excludeDashes = false)
        {
            string _guid = System.Guid.NewGuid().ToString();
            _guid = ApplyFilters(_guid, false, true, excludeDashes);

            return _guid;
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Private back-end method that applies various text/numeric filters to a guid.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="excludeNumbers"></param>
        /// <param name="excludeLetters"></param>
        /// <param name="excludeDashes"></param>
        /// <returns></returns>
        private static string ApplyFilters(string value, bool excludeNumbers, bool excludeLetters, bool excludeDashes)
        {
            if (excludeNumbers)
            {
                Regex _rex = new Regex("[0-9]");
                value = _rex.Replace(value, String.Empty);
            }

            if (excludeLetters)
            {
                Regex _rex = new Regex("[A-z]");
                value = _rex.Replace(value, String.Empty);
            }

            if (excludeDashes)
            {
                value = value.Replace("-", String.Empty);
            }

            return value;
        }
        #endregion
    }
}
