using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataUtilities
{
    public static class AES
    {
        #region Public Encryption Methods
        /// <summary>
        /// Public friendly wrapper method that takes raw text string and password and salt string, and returns an encrypted string
        /// </summary>
        /// <param name="source"></param>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string Encrypt(string source, string password, string salt)
        {
            string _encStr = String.Empty;

            try
            {
                // Turn the input string into a byte array.
                byte[] _rawData = Encoding.Unicode.GetBytes(source);
                byte[] _salt = Encoding.Unicode.GetBytes(salt);
                byte[] _encData = null;

                // Turn the password into Key and IV, using salt. Then encrypt the data.
                Rfc2898DeriveBytes _rfcdb = new Rfc2898DeriveBytes(password, _salt);
                _encData = EncryptDecrypt(_rawData, _rfcdb.GetBytes(32), _rfcdb.GetBytes(16), true);

                // Convert back into a string.
                _encStr = Convert.ToBase64String(_encData);
            }
            catch (Exception)
            {
                throw;
            }

            return _encStr;
        }

        /* 
        public static bool Encrypt(string fileIn, string fileOut, string Password)
        {
            bool bolSuccess = false;

            try
            {
                // Open the two file streams
                FileStream objFileIn = new FileStream(fileIn, FileMode.Open, FileAccess.Read);
                FileStream objFileOut = new FileStream(fileOut, FileMode.OpenOrCreate, FileAccess.Write);

                // Derive a Key and an IV from the Password and create an algorithm
                PasswordDeriveBytes objPassBytes = new PasswordDeriveBytes(Password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

                Rijndael objAlg = Rijndael.Create();
                objAlg.Key = objPassBytes.GetBytes(32);
                objAlg.IV = objPassBytes.GetBytes(16);

                // Create a crypto stream through which we are going to be pumping data.
                // Our fileOut is going to be receiving the encrypted bytes.
                CryptoStream objCrypto = new CryptoStream(objFileOut, objAlg.CreateEncryptor(), CryptoStreamMode.Write);

                // Initialize a buffer and will be processing the input file in chunks.
                int intBuffLen = 4096;
                byte[] bytBuffer = new byte[intBuffLen];
                int intBytesRead;

                do
                {
                    // Read a chunk of data from the input file and encrypt it.
                    intBytesRead = objFileIn.Read(bytBuffer, 0, intBuffLen);
                    objCrypto.Write(bytBuffer, 0, intBuffLen);
                }
                while (intBytesRead != 0);

                // Close inbound file and crypto objects
                objCrypto.Close();
                objFileIn.Close();

                bolSuccess = true;
            }
            catch
            { }

            return bolSuccess;
        }*/
        #endregion

        #region Public Decryption Methods
        /// <summary>
        /// Public friendly wrapper method that takes an ecnrypted string and password and salt string, and returns a decrypted string
        /// </summary>
        /// <param name="source"></param>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string Decrypt(string source, string password, string salt)
        {
            string _decStr = String.Empty;

            try
            {
                // Turn the input string into a byte array.
                byte[] _rawData = Encoding.Unicode.GetBytes(source);
                byte[] _salt = Encoding.Unicode.GetBytes(salt);
                byte[] _decData = null;

                _rawData = Convert.FromBase64String(source);

                // Turn the password into Key and IV, using salt. Then decrypt.
                Rfc2898DeriveBytes _rfcdb = new Rfc2898DeriveBytes(password, _salt);
                _decData = EncryptDecrypt(_rawData, _rfcdb.GetBytes(32), _rfcdb.GetBytes(16), false);

                // Turn the resulting byte array into a string.
                _decStr = System.Text.Encoding.Unicode.GetString(_decData);
            }
            catch (Exception)
            {
                throw;
            }

            return _decStr;
        }

        /* 
        public static bool Decrypt(string fileIn, string fileOut, string Password)
        {
            bool bolSuccess = false;

            try
            {
                // Open the file streams
                FileStream objFileIn = new FileStream(fileIn, FileMode.Open, FileAccess.Read);
                FileStream objFileOut = new FileStream(fileOut, FileMode.OpenOrCreate, FileAccess.Write);

                // Derive a Key and an IV from the Password and create an algorithm
                PasswordDeriveBytes objPassBytes = new PasswordDeriveBytes(Password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                Rijndael objAlg = Rijndael.Create();

                // Set the key and IV.
                objAlg.Key = objPassBytes.GetBytes(32);
                objAlg.IV = objPassBytes.GetBytes(16);

                // Create a crypto stream and pump the data.
                CryptoStream objCrypto = new CryptoStream(objFileOut, objAlg.CreateDecryptor(), CryptoStreamMode.Write);

                // Initialize a buffer and process the input file in chunks.
                int intBufferLen = 4096;
                byte[] bytBuffer = new byte[intBufferLen];
                int intBytesRead;

                do
                {
                    // Read a chunk of data from the input file and decrypt it.
                    intBytesRead = objFileIn.Read(bytBuffer, 0, intBufferLen);
                    objCrypto.Write(bytBuffer, 0, intBytesRead);
                }
                while (intBytesRead != 0);

                // Close the crypto stream (and thus the outbound file), and the inbound file.
                objCrypto.Close();
                objFileIn.Close();

                bolSuccess = true;
            }
            catch
            { }

            return bolSuccess;
        }*/
        #endregion

        #region Private Methods
        /// <summary>
        /// Private back-end method that takes byte arrays and encrypts or decrypts using an AES symmetric algorithm object.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <param name="encrypt"></param>
        /// <returns></returns>
        private static byte[] EncryptDecrypt(byte[] data, byte[] key, byte[] iv, bool encrypt)
        {
            byte[] _data = null;

            try
            {
                // Generate memorystream and aesmanaged objects, and populate the aes 
                // object's properties.
                MemoryStream _mem = new MemoryStream();
                AesManaged _aes = new AesManaged();
                _aes.Key = key;
                _aes.IV = iv;
                _aes.Padding = PaddingMode.PKCS7;

                // Create a CryptoStream into which the data will be encrypted.
                CryptoStream _crypto = new CryptoStream(
                    _mem,
                    (encrypt ? _aes.CreateEncryptor() : _aes.CreateDecryptor()),
                    CryptoStreamMode.Write);

                // Write the data and close it.
                _crypto.Write(data, 0, data.Length);
                _crypto.Close();

                // Get the encrypted data from the MemoryStream.
                _data = _mem.ToArray();
            }
            catch (CryptographicException ex)
            {
                if (ex.Message == "Padding is invalid and cannot be removed.")
                {
                    // Swallow this error, as it's caused by the salt or password not matching.
                    // Throw a single element array item back to avoid a null exception.
                    _data = new byte[1];
                }
            }
            catch (Exception)
            {
                throw;
            }

            return _data;
        }
        #endregion
    }
}
