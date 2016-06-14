using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Collections.Generic;

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

        [TestMethod]
        public void DelimitedStringToIntArrayFilteredSuccess()
        {
            string _list = "1,2,3,x,5";
            Trace.WriteLine(String.Format("Delimited string: {0}", _list));

            int[] _output = _list.StringToIntArray(',', true);
            Trace.WriteLine("Array output:");
            foreach (int x in _output)
            {
                Trace.WriteLine(String.Format("- {0}", x));
            }
            Trace.WriteLine(String.Format("Length: {0}", _output.Length));

            Assert.AreEqual(4, _output.Length);
        }

        [TestMethod]
        public void DelimitedStringToIntArrayFilteredFail()
        {
            string _list = "1,2,3,x,5";
            Trace.WriteLine(String.Format("Delimited string: {0}", _list));

            int[] _output = _list.StringToIntArray(',', true);
            Trace.WriteLine("Array output:");
            foreach (int x in _output)
            {
                Trace.WriteLine(String.Format("- {0}", x));
            }
            Trace.WriteLine(String.Format("Length: {0}", _output.Length));

            Assert.AreNotEqual(5, _output.Length);
        }

        [TestMethod]
        public void IntArrayToDelimitedStringSuccess()
        {
            int[] _array = new int[3];
            _array[0] = 1;
            _array[1] = 2;
            _array[2] = 3;
            Trace.WriteLine(String.Format("Array length: {0}", _array.Length));

            string _delim = _array.IntArrayToDelimitedString(',');
            Trace.WriteLine(String.Format("Output: {0}", _delim));

            Assert.AreEqual("1,2,3", _delim);
        }

        [TestMethod]
        public void CalculateAgeTestSuccess()
        {
            DateTime _dob = new DateTime(1980, 8, 1);
            Trace.WriteLine(String.Format("Date of birth: {0}", _dob.ToShortDateString()));

            int _age = _dob.CalculateAge();
            Trace.WriteLine(String.Format("Current age: {0}", _age));

            Assert.AreEqual(35, _age);
        }

        [TestMethod]
        public void PascalCaseToSentenceSuccess()
        {
            string _value = "TheCatSatOnTheMat";
            Trace.WriteLine(String.Format("Pascal value: {0}", _value));

            string _output = _value.PascalCaseToSentence();
            Trace.WriteLine(String.Format("Converted sentence: {0}", _output));

            Assert.AreEqual("The cat sat on the mat", _output);
        }
    }
}
