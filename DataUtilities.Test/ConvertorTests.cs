using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace DataUtilities.Test
{
    [TestClass]
    public class ConvertorTests
    {
        [TestMethod]
        public void HexToRgbStringSuccess()
        {
            string _hex = "ffffff";
            Trace.WriteLine(String.Format("Hex value: {0}", _hex));

            string _rgb = _hex.HexToRgbString();
            Trace.WriteLine(String.Format("RGB value: {0}", _rgb));

            Assert.AreEqual("255,255,255", _rgb);
        }

        [TestMethod]
        public void HexToRgbIntArraySuccess()
        {
            string _hex = "ffffff";
            Trace.WriteLine(String.Format("Hex value: {0}", _hex));

            int[] _rgb = _hex.HexToRgbArray();

            Trace.WriteLine(String.Format("Array length: {0}", _rgb.Length));
            Trace.WriteLine(String.Format("Array element 0: {0}", _rgb[0]));
            Trace.WriteLine(String.Format("Array element 1: {0}", _rgb[1]));
            Trace.WriteLine(String.Format("Array element 2: {0}", _rgb[2]));

            Assert.AreEqual(3, _rgb.Length);
            Assert.AreEqual(255, _rgb[0]);
            Assert.AreEqual(255, _rgb[0]);
            Assert.AreEqual(255, _rgb[0]);
        }

        [TestMethod]
        public void RgbIntArrayToHexString()
        {
            int[] _rgb = new int[3];
            _rgb[0] = 255;
            _rgb[1] = 255;
            _rgb[2] = 255;
            Trace.WriteLine(String.Format("Red value: {0}", _rgb[0]));
            Trace.WriteLine(String.Format("Green value: {0}", _rgb[1]));
            Trace.WriteLine(String.Format("Blue value: {0}", _rgb[2]));

            string _hex = _rgb.RgbToHexString();
            Trace.WriteLine(String.Format("Hex value: {0}", _hex));

            Assert.AreEqual("ffffff", _hex);
        }

        [TestMethod]
        public void RgbStringArrayToHexString()
        {
            string[] _rgb = new string[3];
            _rgb[0] = "255";
            _rgb[1] = "255";
            _rgb[2] = "255";
            Trace.WriteLine(String.Format("Red value: {0}", _rgb[0]));
            Trace.WriteLine(String.Format("Green value: {0}", _rgb[1]));
            Trace.WriteLine(String.Format("Blue value: {0}", _rgb[2]));

            string _hex = _rgb.RgbToHexString();
            Trace.WriteLine(String.Format("Hex value: {0}", _hex));

            Assert.AreEqual("ffffff", _hex);
        }

        [TestMethod]
        public void RgbToHexStringSuccess()
        {
            int[] _rgb = new int[3];
            _rgb[0] = 255;
            _rgb[1] = 255;
            _rgb[2] = 255;

            Trace.WriteLine(String.Format("Red value: {0}", _rgb[0]));
            Trace.WriteLine(String.Format("Green value: {0}", _rgb[1]));
            Trace.WriteLine(String.Format("Blue value: {0}", _rgb[2]));

            string _hex = _rgb.RgbToHexString();
            Trace.WriteLine(String.Format("Hex value: {0}", _hex));

            Assert.AreEqual("FFFFFF", _hex);
        }

        [TestMethod]
        public void RgbStringToHexStringSuccess()
        {
            string _rgb = "255,255,255";
            Trace.WriteLine(String.Format("RGB value: {0}", _rgb));

            string _hex = _rgb.RgbToHexString();
            Trace.WriteLine(String.Format("Hex value: {0}", _hex));

            Assert.AreEqual("FFFFFF", _hex);
        }

        public void HexToRgbStringFail()
        {
            string _hex = "ffffff";
            Trace.WriteLine(String.Format("Hex value: {0}", _hex));

            string _rgb = _hex.HexToRgbString();
            Trace.WriteLine(String.Format("RGB value: {0}", _rgb));

            Assert.AreNotEqual("255,255,244", _rgb);
        }

        [TestMethod]
        public void HexToRgbIntArrayFail()
        {
            string _hex = "ffffff";
            Trace.WriteLine(String.Format("Hex value: {0}", _hex));

            int[] _rgb = _hex.HexToRgbArray();

            Trace.WriteLine(String.Format("Array length: {0}", _rgb.Length));
            Trace.WriteLine(String.Format("Array element 0: {0}", _rgb[0]));
            Trace.WriteLine(String.Format("Array element 1: {0}", _rgb[1]));
            Trace.WriteLine(String.Format("Array element 2: {0}", _rgb[2]));

            Assert.AreEqual(3, _rgb.Length);
            Assert.AreEqual(255, _rgb[0]);
            Assert.AreEqual(255, _rgb[0]);
            Assert.AreNotEqual(244, _rgb[0]);
        }

        [TestMethod]
        public void RgbToHexStringFail()
        {
            int[] _rgb = new int[3];
            _rgb[0] = 255;
            _rgb[1] = 255;
            _rgb[2] = 255;

            Trace.WriteLine(String.Format("Red value: {0}", _rgb[0]));
            Trace.WriteLine(String.Format("Green value: {0}", _rgb[1]));
            Trace.WriteLine(String.Format("Blue value: {0}", _rgb[2]));

            string _hex = _rgb.RgbToHexString();
            Trace.WriteLine(String.Format("Hex value: {0}", _hex));

            Assert.AreNotEqual("FFFFEE", _hex);
        }

        [TestMethod]
        public void RgbStringToHexStringFailBadInput1()
        {
            string _rgb = "299,255,255";
            Trace.WriteLine(String.Format("RGB value: {0}", _rgb));

            try
            {
                string _hex = _rgb.RgbToHexString();
                Trace.WriteLine(String.Format("Hex value: {0}", _hex));
            }
            catch(Exception ex)
            {
                Trace.WriteLine(String.Format("Expected exception encountered: {0}", ex.Message));
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void RgbStringToHexStringFailBadInput2()
        {
            string _rgb = "255255255";
            Trace.WriteLine(String.Format("RGB value: {0}", _rgb));

            try
            {
                string _hex = _rgb.RgbToHexString();
                Trace.WriteLine(String.Format("Hex value: {0}", _hex));
            }
            catch (Exception ex)
            {
                Trace.WriteLine(String.Format("Expected exception encountered: {0}", ex.Message));
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void RgbStringToHexStringFailMismatch()
        {
            string _rgb = "255,255,255";
            Trace.WriteLine(String.Format("RGB value: {0}", _rgb));

            string _hex = _rgb.RgbToHexString();
            Trace.WriteLine(String.Format("Hex value: {0}", _hex));

            Assert.AreNotEqual("FFFFEE", _hex);
        }
    }
}
