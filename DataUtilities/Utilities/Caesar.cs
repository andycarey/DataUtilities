using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataUtilities
{
    public static class Caesar
    {
        private const string _source = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!@&*+/? -_=.:;,~|1234567890";
        private const string _target = "k3R.0U@bvCi W+os,f2~AEdG8z!KnN6JYqyjM*xLtpBS;m5QHua1_VI/O?De:Z=T9FrPghX47|wl&c-";
        private const char _version = 'b';

        #region Public Methods
        /// <summary>
        /// Caesar cypher method that encryots a string. Made for the fun of it, and should not be used in production environments!!
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string Encrypt(string source)
        {
            return GoEncrypt(source);
        }

        /// <summary>
        /// Caesar cypher method that decrypts a string. Made for the fun of it, and should not be used in production environments!!
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string Decrypt(string source)
        {
            return GoDecrypt(source);
        }
        #endregion

        #region Private Methods
        private static string GoEncrypt(string value)
        {
            string _output = "";

            CryptoRandom _rng = new CryptoRandom();
            int _rndValue = 0;
            int _shift = 0;
            int _case = 0;

            // Add four leading superfluous values (letters or numbers)
            for (int intCurrFodder = 0; intCurrFodder < 4; intCurrFodder++)
            {
                _rndValue = _rng.Next(36);
                _case = _rng.Next(2);

                if (_rndValue < 27)
                {
                    _output += (_case == 0) ? Convert.ToChar(_rndValue + 97) : Convert.ToChar(_rndValue + 65);
                }
                else
                {
                    _output += (_rndValue - 26);
                }
            }

            // Add the shift-key value
            _shift = _rng.Next(87);
            if (_shift < 10)
            {
                _output += "0" + _shift;
            }
            else
            {
                _output += _shift;
            }

            char[] chrBrokenString = value.ToCharArray();

            for (int intCurrLetter = 0; intCurrLetter < value.Length; intCurrLetter++)
            {
                if (_source.IndexOf(chrBrokenString[intCurrLetter]) < 0)
                {
                    _output += chrBrokenString[intCurrLetter];
                }
                else if ((_source.IndexOf(chrBrokenString[intCurrLetter]) + _shift) > (_source.Length - 1))
                {
                    _output += _target.Substring(((_source.IndexOf(chrBrokenString[intCurrLetter]) + _shift) - (_source.Length)), 1);
                }
                else
                {
                    _output += _target.Substring(_source.IndexOf(chrBrokenString[intCurrLetter]) + _shift, 1);
                }
            }

            // Add a trailing superfluous value (letter or number)
            _rndValue = _rng.Next(36);
            _case = _rng.Next(2);

            if (_rndValue < 27)
            {
                _output += (_case == 0) ? Convert.ToChar(_rndValue + 97) : Convert.ToChar(_rndValue + 65);
            }
            else
            {
                _output += (_rndValue - 26);
            }

            // Add the versioning letter
            _output += _version.ToString();

            // Add a final superfluous number
            _output += _rng.Next(9);

            return _output;
        }

        private static string GoDecrypt(string value)
        {
            string _output = String.Empty;

            try
            {
                // Remove superfluous characters and grab the shift key
                string _good = value.Substring(6, (value.Length - 9));
                int _shift = Int32.Parse(value.Substring(4, 2));

                char[] chrBrokenString = _good.ToCharArray();

                // Cycle through each encrypted character and calculate the correct character
                for (int intCurrLetter = 0; intCurrLetter < _good.Length; intCurrLetter++)
                {
                    if (_target.IndexOf(chrBrokenString[intCurrLetter]) < 0)
                    {
                        _output += chrBrokenString[intCurrLetter];
                    }
                    else if ((_target.IndexOf(chrBrokenString[intCurrLetter]) - _shift) < 0)
                    {
                        _output += _source.Substring(_target.Length - (_shift - _target.IndexOf(chrBrokenString[intCurrLetter])), 1);
                    }
                    else
                    {
                        _output += _source.Substring(_target.IndexOf(chrBrokenString[intCurrLetter]) - _shift, 1);
                    }
                }
            }
            catch
            { }

            return _output;
        }
        #endregion
    }
}
