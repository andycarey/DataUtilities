using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataUtilities
{
    public static class Hash
    {
        #region Public methods
        /// <summary>
        /// Extension method to hash a string using the SHA1 algorithm. This algorithm is no longer secure and should only be used for legacy evaluations!
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SHA1(this string value)
        {
            byte[] _ba = System.Text.Encoding.UTF8.GetBytes(value);
            SHA1 _sha = new SHA1CryptoServiceProvider();
            return ByteArrayToString(_sha.ComputeHash(_ba));
        }

        /// <summary>
        /// Extension method to hash a string using the SHA256 algorithm.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SHA256(this string value)
        {
            byte[] _ba = System.Text.Encoding.UTF8.GetBytes(value);
            SHA256 _sha = new SHA256CryptoServiceProvider();
            return ByteArrayToString(_sha.ComputeHash(_ba));
        }

        /// <summary>
        /// Extension method to hash a string using the SHA385 algorithm.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SHA384(this string value)
        {
            byte[] _ba = System.Text.Encoding.UTF8.GetBytes(value);
            SHA384 _sha = new SHA384CryptoServiceProvider();
            return ByteArrayToString(_sha.ComputeHash(_ba));
        }

        /// <summary>
        /// Extension method to hash a string using the SHA512 algorithm.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SHA512(this string value)
        {
            byte[] _ba = System.Text.Encoding.UTF8.GetBytes(value);
            SHA512 _sha = new SHA512CryptoServiceProvider();
            return ByteArrayToString(_sha.ComputeHash(_ba));
        }
        #endregion

        #region Private methods
        private static string ByteArrayToString(byte[] value)
        {
            var _sb = new StringBuilder();
            foreach (byte b in value)
            {
                var hex = b.ToString("x2");
                _sb.Append(hex);
            }
            return _sb.ToString();
        }
        #endregion
    }
}
