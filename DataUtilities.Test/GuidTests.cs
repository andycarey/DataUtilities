using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace DataUtilities.Test
{
    [TestClass]
    public class GuidTests
    {
        [TestMethod]
        public void GuidWithNumbersOnly()
        {
            string _guid = Guid.GuidFilteredNumbers(true);
            Trace.WriteLine(String.Format("Guid: {0}", _guid));

            Regex _rex = new Regex("^[0-9]+$");
            bool _success = _rex.IsMatch(_guid);

            Assert.IsTrue(_success);
        }

        [TestMethod]
        public void GuidUpperCase()
        {
            string _guid = Guid.GuidUppercase();
            Trace.WriteLine(String.Format("Guid: {0}", _guid));

            Regex _rex = new Regex("^[A-Z0-9-]+$");
            bool _success = _rex.IsMatch(_guid);

            Assert.IsTrue(_success);
        }

        [TestMethod]
        public void GuidLowerCase()
        {
            string _guid = Guid.GuidLowercase();
            Trace.WriteLine(String.Format("Guid: {0}", _guid));

            Regex _rex = new Regex("^[a-z0-9-]+$");
            bool _success = _rex.IsMatch(_guid);

            Assert.IsTrue(_success);
        }

        [TestMethod]
        public void GuidUpperCaseNoDashes()
        {
            string _guid = Guid.GuidUppercase(false, true);
            Trace.WriteLine(String.Format("Guid: {0}", _guid));

            Regex _rex = new Regex("^[A-Z0-9]+$");
            bool _success = _rex.IsMatch(_guid);

            Assert.IsTrue(_success);
        }

        [TestMethod]
        public void GuidLowererCaseNoDashesOrNumbers()
        {
            string _guid = Guid.GuidLowercase(true, true);
            Trace.WriteLine(String.Format("Guid: {0}", _guid));

            Regex _rex = new Regex("^[a-z]+$");
            bool _success = _rex.IsMatch(_guid);

            Assert.IsTrue(_success);
        }

        [TestMethod]
        public void GuidLowerCaseNoDashesOrNumbers()
        {
            string _guid = Guid.GuidLowercase(true, true);
            Trace.WriteLine(String.Format("Guid: {0}", _guid));

            Regex _rex = new Regex("^[a-z]+$");
            bool _success = _rex.IsMatch(_guid);

            Assert.IsTrue(_success);
        }
    }
}
