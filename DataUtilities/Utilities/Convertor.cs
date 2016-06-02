using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataUtilities
{
    public static class Convertor
    {
        #region Hex to RGB
        /// <summary>
        /// Extension method to convert a hex string into an RGB int array.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int[] HexToRgbArray(this string value)
        {
            int[] _rgbArray = { -1, -1, -1 };
            char[] chrHex = value.ToCharArray();

            try
            {
                // TODO: Add more validation handling!
                if (chrHex.Length == 6)
                {
                    int _red = (System.Convert.ToInt32(chrHex[0].ToString(), 16) * 16) + (System.Convert.ToInt32(chrHex[1].ToString(), 16));
                    int _green = (System.Convert.ToInt32(chrHex[2].ToString(), 16) * 16) + (System.Convert.ToInt32(chrHex[3].ToString(), 16));
                    int _blue = (System.Convert.ToInt32(chrHex[4].ToString(), 16) * 16) + (System.Convert.ToInt32(chrHex[5].ToString(), 16));

                    _rgbArray[0] = _red;
                    _rgbArray[1] = _green;
                    _rgbArray[2] = _blue;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return _rgbArray;
        }

        /// <summary>
        /// Extension method to convert hex string into comma-separated RGB string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string HexToRgbString(this string value)
        {
            int[] _array = HexToRgbArray(value);

            return String.Concat(_array[0].ToString(), ",", _array[1].ToString(), ",", _array[2].ToString());
        }
        #endregion

        #region RGB to Hex
        /// <summary>
        /// Convert an RGB string array into a hex string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string RgbToHexString(this string[] value)
        {
            string _output = String.Empty;
            string[] _rgbArray;

            try
            {
                if (value.Length != 3)
                {
                    throw new Exception("Array must contain three elements");
                }
                else
                {
                    _rgbArray = value.Select(v => Int32.Parse(v).ToString("x2")).ToArray();
                    _output = String.Concat(_rgbArray[0].ToString(), _rgbArray[1].ToString(), _rgbArray[2].ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }

            return _output;
        }

        /// <summary>
        /// Convert an RGB int array into a hex string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string RgbToHexString(this int[] value)
        {
            try
            {
                string[] _strVals = value.Select(v => v.ToString()).ToArray();
                return RgbToHexString(_strVals);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Extension method to convert string of RGB values into hex string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string RgbToHexString(this string value)
        {
            string _output = String.Empty;

            try
            {
                int[] _rgbArray = new int[3];
                string[] _rbgRawArray = new string[3];

                Regex _rex = new Regex("^([0-9]{1,3})([,]{1})([0-9]{1,3})([,]{1})([0-9]{1,3})$");

                if (value.Length != 11 || !_rex.IsMatch(value))
                {
                    throw new Exception("String must follow the pattern of 111,111,111");
                }

                _rbgRawArray = value.Split(',');
                for (int c = 0; c < 3; c++)
                {
                    _rgbArray[c] = Int32.Parse(_rbgRawArray[c]);
                }

                if ((_rgbArray[0] > 255 || _rgbArray[0] < 0)
                    || (_rgbArray[1] > 255 || _rgbArray[1] < 0)
                    || (_rgbArray[2] > 255 || _rgbArray[2] < 0))
                {
                    throw new Exception("One or more values exceed Hex limits");
                }
                else
                {
                    string _red = _rgbArray[0].ToString("X");
                    string _green = _rgbArray[1].ToString("X");
                    string _blue = _rgbArray[2].ToString("X");

                    _output = String.Concat(_red, _green, _blue);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return _output;
        }
        #endregion
    }
}
