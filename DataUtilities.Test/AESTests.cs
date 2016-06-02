using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace DataUtilities.Test
{
    [TestClass]
    public class AESTests
    {
        [TestMethod]
        public void AESEncryptDecryptSuccess()
        {
            Trace.WriteLine("Starting unit test...");
            string _rawText = "This is a test!";
            string _password = "password123";
            string _salt = "salt123";
            Trace.WriteLine(String.Format("Raw text: {0}", _rawText));

            string _encryptedText = AES.Encrypt(_rawText, _password, _salt);
            Trace.WriteLine(String.Format("Encrypted text: {0}", _encryptedText));

            string _decryptedText = AES.Decrypt(_encryptedText, _password, _salt);
            Trace.WriteLine(String.Format("Decrypted text: {0}", _decryptedText));

            Assert.AreEqual(_rawText, _decryptedText);
        }

        [TestMethod]
        public void AESEncryptDecryptFailBadSalt()
        {
            Trace.WriteLine("Starting unit test...");
            string _rawText = "This is a test!";
            string _password = "password123";
            string _salt = "salt123";
            Trace.WriteLine(String.Format("Raw text: {0}", _rawText));

            string _encryptedText = AES.Encrypt(_rawText, _password, _salt);
            Trace.WriteLine(String.Format("Encrypted text: {0}", _encryptedText));

            string _decryptedText = AES.Decrypt(_encryptedText, _password, "salt125");
            Trace.WriteLine(String.Format("Decrypted text: {0}", _decryptedText));

            Assert.AreNotEqual(_rawText, _decryptedText);
        }

        [TestMethod]
        public void AESDecryptFailNotEncrypted()
        {
            Trace.WriteLine("Starting unit test...");
            string _encText = "This isn't really encrypted!";
            string _password = "password123";
            string _salt = "salt123";
            Trace.WriteLine(String.Format("Encrypted text: {0}", _encText));

            try
            {
                string _decryptedText = AES.Decrypt(_encText, _password, _salt);
                Trace.WriteLine(String.Format("Decrypted text: {0}", _decryptedText));
            }
            catch (FormatException ex)
            {
                if (ex.Message == "Source is not AES-encrypted")
                {
                    Trace.WriteLine(String.Format("Unit test failed as expected, encrypted text is not encrypted!"));
                    Assert.IsTrue(true);
                }
                else
                {
                    Trace.WriteLine(String.Format("Unit test failed unexpectedly, encrypted text is encrypted or another error occurred!"));
                    Assert.IsTrue(false);
                }
            }
        }

        [TestMethod]
        public void AESEncryptDecryptFailBadPassword()
        {
            Trace.WriteLine("Starting unit test...");
            string _rawText = "This is a test!";
            string _password = "password123";
            string _salt = "salt123";
            Trace.WriteLine(String.Format("Raw text: {0}", _rawText));

            string _encryptedText = AES.Encrypt(_rawText, _password, _salt);
            Trace.WriteLine(String.Format("Encrypted text: {0}", _encryptedText));

            string _decryptedText = AES.Decrypt(_encryptedText, "password124", _salt);
            Trace.WriteLine(String.Format("Decrypted text: {0}", _decryptedText));

            Assert.AreNotEqual(_rawText, _decryptedText);
        }

        [TestMethod]
        public void AESEncryptDecryptFailBadEncryptedText()
        {
            Trace.WriteLine("Starting unit test...");
            string _rawText = "This is a test!";
            string _password = "password123";
            string _salt = "salt123";
            Trace.WriteLine(String.Format("Raw text: {0}", _rawText));

            string _encryptedText = AES.Encrypt(_rawText, _password, _salt);
            Trace.WriteLine(String.Format("Encrypted text: {0}", _encryptedText));

            char _badChar = (_encryptedText.ToCharArray())[1];
            _encryptedText = _encryptedText.Replace(_badChar, 'X');
            Trace.WriteLine(String.Format("Deliberately corrupting encrypted text. Replacing chars {0} with {1}", _badChar, 'X'));
            Trace.WriteLine(String.Format("New encrypted text: {0}", _encryptedText));

            string _decryptedText = AES.Decrypt(_encryptedText, _password, _salt);
            Trace.WriteLine(String.Format("Decrypted text: {0}", _decryptedText));

            Assert.AreNotEqual(_rawText, _decryptedText);
        }
    }
}
