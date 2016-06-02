using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace DataUtilities.Test
{
    [TestClass]
    public class PasswordTests
    {
        [TestMethod]
        public void GeneratePasswordSuccessMixedFull()
        {
            Trace.WriteLine("Starting unit test...");
            int _min = 8;
            int _max = 11;
            bool _mixed = true;
            bool _numbers = true;
            bool _specials = true;
            Trace.WriteLine(String.Format("Minimum length: {0}", _min));
            Trace.WriteLine(String.Format("Maximum length: {0}", _max));
            Trace.WriteLine(String.Format("Mixed case: {0}", _mixed));
            Trace.WriteLine(String.Format("Numbers: {0}", _numbers));
            Trace.WriteLine(String.Format("Specials: {0}", _specials));

            string _password = Password.Generate(_min, _max, _mixed, _numbers, _specials);
            Trace.WriteLine(String.Format("New password: {0}", _password));

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void GeneratePasswordSuccessAllLowercaseLetters()
        {
            Trace.WriteLine("Starting unit test...");
            int _min = 8;
            int _max = 11;
            bool _mixed = false;
            bool _numbers = false;
            bool _specials = false;
            Trace.WriteLine(String.Format("Minimum length: {0}", _min));
            Trace.WriteLine(String.Format("Maximum length: {0}", _max));
            Trace.WriteLine(String.Format("Mixed case: {0}", _mixed));
            Trace.WriteLine(String.Format("Numbers: {0}", _numbers));
            Trace.WriteLine(String.Format("Specials: {0}", _specials));

            string _password = Password.Generate(_min, _max, _mixed, _numbers, _specials);
            Trace.WriteLine(String.Format("New password: {0}", _password));

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void GeneratePasswordFailBadLength()
        {
            Trace.WriteLine("Starting unit test...");

            try
            {
                int _min = 4;
                int _max = 11;
                bool _mixed = true;
                bool _numbers = true;
                bool _specials = true;
                Trace.WriteLine(String.Format("Minimum length: {0}", _min));
                Trace.WriteLine(String.Format("Maximum length: {0}", _max));
                Trace.WriteLine(String.Format("Mixed case: {0}", _mixed));
                Trace.WriteLine(String.Format("Numbers: {0}", _numbers));
                Trace.WriteLine(String.Format("Specials: {0}", _specials));

                string _password = Password.Generate(_min, _max, _mixed, _numbers, _specials);
                Trace.WriteLine(String.Format("New password: {0}", _password));
            }
            catch (FormatException ex)
            {
                if (ex.Message == "Password length must be between 6 and 16 characters")
                {
                    Trace.WriteLine(String.Format("Unit test failed as expected, invalid password length!"));
                    Assert.IsTrue(true);
                }
                else
                {
                    Trace.WriteLine(String.Format("Unit test failed unexpectedly, another error occurred!"));
                    Assert.IsTrue(false);
                }
            }
        }
    }
}
