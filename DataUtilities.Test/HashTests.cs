using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataUtilities.Test
{
    [TestClass]
    public class HashTests
    {
        [TestMethod]
        public void SHA1Success()
        {
            string _raw = "test123";
            string _hashed = _raw.SHA1();
            Assert.AreEqual("7288edd0fc3ffcbe93a0cf06e3568e28521687bc", _hashed);
        }

        [TestMethod]
        public void SHA256Success()
        {
            string _raw = "test123";
            string _hashed = _raw.SHA256();
            Assert.AreEqual("ecd71870d1963316a97e3ac3408c9835ad8cf0f3c1bc703527c30265534f75ae", _hashed);
        }

        [TestMethod]
        public void SHA384Success()
        {
            string _raw = "test123";
            string _hashed = _raw.SHA384();
            Assert.AreEqual("c51dcc4e0deaee00fa5af30e29b6e1acbf32fcb3cea8c4b5cdeaecece8e248df439b2da1b834cb67bbafd2fa07d02f49", _hashed);
        }

        [TestMethod]
        public void SHA512Success()
        {
            string _raw = "test123";
            string _hashed = _raw.SHA512();
            Assert.AreEqual("daef4953b9783365cad6615223720506cc46c5167cd16ab500fa597aa08ff964eb24fb19687f34d7665f778fcb6c5358fc0a5b81e1662cf90f73a2671c53f991", _hashed);
        }

        [TestMethod]
        public void SHA1Fail()
        {
            string _raw = "test123";
            string _hashed = _raw.SHA1();
            Assert.AreNotEqual("XXX8edd0fc3ffcbe93a0cf06e3568e28521687bc", _hashed);
        }

        [TestMethod]
        public void SHA256Fail()
        {
            string _raw = "test123";
            string _hashed = _raw.SHA256();
            Assert.AreNotEqual("XXX71870d1963316a97e3ac3408c9835ad8cf0f3c1bc703527c30265534f75ae", _hashed);
        }

        [TestMethod]
        public void SHA384Fail()
        {
            string _raw = "test123";
            string _hashed = _raw.SHA384();
            Assert.AreNotEqual("XXXdcc4e0deaee00fa5af30e29b6e1acbf32fcb3cea8c4b5cdeaecece8e248df439b2da1b834cb67bbafd2fa07d02f49", _hashed);
        }

        [TestMethod]
        public void SHA512Fail()
        {
            string _raw = "test123";
            string _hashed = _raw.SHA512();
            Assert.AreNotEqual("XXXf4953b9783365cad6615223720506cc46c5167cd16ab500fa597aa08ff964eb24fb19687f34d7665f778fcb6c5358fc0a5b81e1662cf90f73a2671c53f991", _hashed);
        }
    }
}
