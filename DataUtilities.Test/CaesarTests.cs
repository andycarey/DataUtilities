using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace DataUtilities.Test
{
    [TestClass]
    public class CaesarTests
    {
        [TestMethod]
        public void CaesarEncryptDecryptSuccess()
        {
            Trace.WriteLine("Starting unit test...");
            string _rawText = "This is a test!";
            Trace.WriteLine(String.Format("Raw text: {0}", _rawText));

            string _encryptedText = Caesar.Encrypt(_rawText);
            Trace.WriteLine(String.Format("Encrypted text: {0}", _encryptedText));

            string _decryptedText = Caesar.Decrypt(_encryptedText);
            Trace.WriteLine(String.Format("Decrypted text: {0}", _decryptedText));

            Assert.AreEqual(_rawText, _decryptedText);
        }
    }
}
