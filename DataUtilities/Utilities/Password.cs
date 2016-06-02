using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataUtilities
{
    public class Password
    {
        static CryptoRandom _rng = new CryptoRandom();

        #region Public Methods
        /// <summary>
        /// Generate a randomized password based on various specific parameters.
        /// </summary>
        /// <param name="minLength"></param>
        /// <param name="maxLength"></param>
        /// <param name="includeMixedCaseLetters"></param>
        /// <param name="includeNumbers"></param>
        /// <param name="includeSpecials"></param>
        /// <returns></returns>
        public static string Generate(int minLength, int maxLength, bool includeMixedCaseLetters, bool includeNumbers, bool includeSpecials)
        {
            try
            {
                if (minLength < 6 || maxLength > 16)
                {
                    throw new FormatException("Password length must be between 6 and 16 characters");
                }

                int _exactLength = CalculatePasswordLength(minLength, maxLength);
                string _mask = GetMask(_exactLength, includeMixedCaseLetters, includeNumbers, includeSpecials);
                string _raw = ReplaceMask(_mask);
                return ShufflePassword(_raw);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Overload method to generate a randomized password. Only requires min and max length. All bools in the main method are assumed to be true.
        /// </summary>
        /// <param name="minLength"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static string Generate(int minLength, int maxLength)
        {
            return Generate(minLength, maxLength, true, true, true);
        }

        /// <summary>
        /// Overload method to generate a randomized password. Takes exact length.
        /// </summary>
        /// <param name="length"></param>
        /// <param name="includeMixedCaseLetters"></param>
        /// <param name="includeNumbers"></param>
        /// <param name="includeSpecials"></param>
        /// <returns></returns>
        public static string Generate(int length, bool includeMixedCaseLetters, bool includeNumbers, bool includeSpecials)
        {
            return Generate(length, length, includeMixedCaseLetters, includeNumbers, includeSpecials);
        }

        /// <summary>
        /// Overload method to generate a randomized password. Takes only length. All bools in the main method are assumed to be true.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Generate(int length)
        {
            return Generate(length, length, true, true, true);
        }

        /// <summary>
        /// Empty overload method to generate a randomized password. Length is between 6 and 16 and all bools are assumed to be true.
        /// </summary>
        /// <returns></returns>
        public static string Generate()
        {
            return Generate(6, 16, true, true, true);
        }
        #endregion

        #region Private Helper Methods
        private static string ShufflePassword(string password)
        {
            return new string(password
                .OrderBy(a => _rng.Next())
                .ToArray());
        }

        private static string ReplaceMask(string mask)
        {
            string _output = String.Empty;
            const string _letters = "abcdefghijklmnopqrstuvwxyz";
            const string _numbers = "0123456789";
            const string _specials = "!@#$%*?+-=_";
            int _rnd = 0;

            foreach (char c in mask.ToCharArray())
            {
                if (c == 'W' || c == 'w')
                {
                    _rnd = _rng.Next(26);
                    _output += (c == 'W'
                        ? Char.ToUpper(_letters[_rnd])
                        : _letters[_rnd]);
                }
                else if (c == 'n')
                {
                    _rnd = _rng.Next(9);
                    _output += _numbers[_rnd];
                }
                else if (c == 's')
                {
                    _rnd = _rng.Next(11);
                    _output += _specials[_rnd];
                }
            }

            return _output;
        }

        private static int CalculatePasswordLength(int minLength, int maxLength)
        {
            return _rng.Next(minLength, maxLength);
        }

        private static string GetMask(int length, bool includeMixedCaseLetters, bool includeNumbers, bool includeSpecials)
        {
            string _mask = String.Empty;

            // Calculate the mask using:
            //   W = uppercase letter
            //   w = lowercase letter
            //   n = number
            //   s = special character
            // Not elegant or pretty, but it's effective. Mask is used as a placeholder 
            // for final password characters.
            if (includeMixedCaseLetters && includeNumbers && includeSpecials)
            {
                switch (length)
                {
                    case 7:
                        _mask = "WWwwnns";
                        break;
                    case 8:
                        _mask = "WWwwwnns";
                        break;
                    case 9:
                        _mask = "WWWwwwnns";
                        break;
                    case 10:
                        _mask = "WWWwwwnnss";
                        break;
                    case 11:
                        _mask = "WWWwwwnnnss";
                        break;
                    case 12:
                        _mask = "WWWwwwwnnnss";
                        break;
                    case 13:
                        _mask = "WWWWwwwwnnnss";
                        break;
                    case 14:
                        _mask = "WWWWwwwwnnnnss";
                        break;
                    case 15:
                        _mask = "WWWWwwwwnnnnsss";
                        break;
                    case 16:
                        _mask = "WWWWwwwwnnnnnsss";
                        break;
                    default: // 6
                        _mask = "WWwwns";
                        break;
                }
            }
            else if (includeMixedCaseLetters && includeNumbers)
            {
                switch (length)
                {
                    case 7:
                        _mask = "WWwwnnn";
                        break;
                    case 8:
                        _mask = "WWwwwnnn";
                        break;
                    case 9:
                        _mask = "WWWwwwnnn";
                        break;
                    case 10:
                        _mask = "WWWwwwnnnn";
                        break;
                    case 11:
                        _mask = "WWWwwwwnnnn";
                        break;
                    case 12:
                        _mask = "WWWWwwwwnnnn";
                        break;
                    case 13:
                        _mask = "WWWWwwwwnnnnn";
                        break;
                    case 14:
                        _mask = "WWWWwwwwwnnnnn";
                        break;
                    case 15:
                        _mask = "WWWWWwwwwwnnnnn";
                        break;
                    case 16:
                        _mask = "WWWWWwwwwwnnnnnn";
                        break;
                    default: // 6
                        _mask = "WWwwns";
                        break;
                }
            }
            else if (includeMixedCaseLetters && includeSpecials)
            {
                switch (length)
                {
                    case 7:
                        _mask = "WWwwsss";
                        break;
                    case 8:
                        _mask = "WWwwwsss";
                        break;
                    case 9:
                        _mask = "WWWwwwsss";
                        break;
                    case 10:
                        _mask = "WWWwwwssss";
                        break;
                    case 11:
                        _mask = "WWWwwwsssss";
                        break;
                    case 12:
                        _mask = "WWWwwwwsssss";
                        break;
                    case 13:
                        _mask = "WWWWwwwwsssss";
                        break;
                    case 14:
                        _mask = "WWWWwwwwssssss";
                        break;
                    case 15:
                        _mask = "WWWWwwwwsssssss";
                        break;
                    case 16:
                        _mask = "WWWWwwwwssssssss";
                        break;
                    default: // 6
                        _mask = "WWwwns";
                        break;
                }
            }
            else if (includeNumbers && includeSpecials)
            {
                switch (length)
                {
                    case 7:
                        _mask = "wwwwnns";
                        break;
                    case 8:
                        _mask = "wwwwwnns";
                        break;
                    case 9:
                        _mask = "wwwwwwnns";
                        break;
                    case 10:
                        _mask = "wwwwwwnnss";
                        break;
                    case 11:
                        _mask = "wwwwwwnnnss";
                        break;
                    case 12:
                        _mask = "wwwwwwwnnnss";
                        break;
                    case 13:
                        _mask = "wwwwwwwwnnnss";
                        break;
                    case 14:
                        _mask = "wwwwwwwwnnnnss";
                        break;
                    case 15:
                        _mask = "wwwwwwwwnnnnsss";
                        break;
                    case 16:
                        _mask = "wwwwwwwwnnnnnsss";
                        break;
                    default: // 6
                        _mask = "wwwwns";
                        break;
                }
            }
            else if (includeNumbers)
            {
                switch (length)
                {
                    case 7:
                        _mask = "wwwwnnn";
                        break;
                    case 8:
                        _mask = "wwwwwnnn";
                        break;
                    case 9:
                        _mask = "wwwwwwnnn";
                        break;
                    case 10:
                        _mask = "wwwwwwnnnn";
                        break;
                    case 11:
                        _mask = "wwwwwwnnnnn";
                        break;
                    case 12:
                        _mask = "wwwwwwwnnnnn";
                        break;
                    case 13:
                        _mask = "wwwwwwwnnnnnn";
                        break;
                    case 14:
                        _mask = "wwwwwwwnnnnnnn";
                        break;
                    case 15:
                        _mask = "wwwwwwwnnnnnnnn";
                        break;
                    case 16:
                        _mask = "wwwwwwwnnnnnnnnn";
                        break;
                    default: // 6
                        _mask = "wwwwnn";
                        break;
                }
            }
            else if (includeSpecials)
            {
                switch (length)
                {
                    case 7:
                        _mask = "wwwwsss";
                        break;
                    case 8:
                        _mask = "wwwwwsss";
                        break;
                    case 9:
                        _mask = "wwwwwwsss";
                        break;
                    case 10:
                        _mask = "wwwwwwssss";
                        break;
                    case 11:
                        _mask = "wwwwwwsssss";
                        break;
                    case 12:
                        _mask = "wwwwwwwsssss";
                        break;
                    case 13:
                        _mask = "wwwwwwwwsssss";
                        break;
                    case 14:
                        _mask = "wwwwwwwwssssss";
                        break;
                    case 15:
                        _mask = "wwwwwwwwsssssss";
                        break;
                    case 16:
                        _mask = "wwwwwwwwssssssss";
                        break;
                    default: // 6
                        _mask = "wwwwss";
                        break;
                }
            }
            else // Only lowercase letters
            {
                switch (length)
                {
                    case 7:
                        _mask = "wwwwwww";
                        break;
                    case 8:
                        _mask = "wwwwwwww";
                        break;
                    case 9:
                        _mask = "wwwwwwwww";
                        break;
                    case 10:
                        _mask = "wwwwwwwwww";
                        break;
                    case 11:
                        _mask = "wwwwwwwwwww";
                        break;
                    case 12:
                        _mask = "wwwwwwwwwwww";
                        break;
                    case 13:
                        _mask = "wwwwwwwwwwwww";
                        break;
                    case 14:
                        _mask = "wwwwwwwwwwwwww";
                        break;
                    case 15:
                        _mask = "wwwwwwwwwwwwwww";
                        break;
                    case 16:
                        _mask = "wwwwwwwwwwwwwwww";
                        break;
                    default: // 6
                        _mask = "wwwwww";
                        break;
                }
            }

            return _mask;
        }
        #endregion
    }
}
