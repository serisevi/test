using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using App16112020;

namespace App16112020
{
    [TestFixture]
    public class ConverterTest
    {
        [Test]
        public void TestConverterReturnsRightValue()
        {
            UahConverter converter = new UahConverter(0.25, 10, 8);
            converter.OutputCurrency = Currency.EUR;
            converter.Value = 1000;
            Assert.AreEqual(100, converter.Value);
        }
        [Test]
        public void TestConverterGenereteArgumentException()
        {
            UahConverter converter = new UahConverter(0.25, 10, 8);
            converter.OutputCurrency = Currency.EUR;
            converter.Value = -1000;
        }
        [Test]
        public void TestConverterGenereteCtorArgumentException()
        {
            try
            {
                UahConverter converter = new UahConverter(0.25, -10, 8);
                converter.OutputCurrency = Currency.EUR;
                converter.Value = 1000;
            }
            catch (ArgumentException ex)
            {
                StringAssert.Contains(ex.Message, "Ctor");
                return;
            }
            Assert.Fail("No exception was thrown");
        }
        [Test]
        public void TestConverterGenereteInputValueArgumentException()
        {
            try
            {
                UahConverter converter = new UahConverter(0.25, 10, 8);
                converter.OutputCurrency = Currency.EUR;
                converter.Value = -1000;
            }
            catch (ArgumentException ex)
            {
                StringAssert.Contains(ex.ParamName, "Value");
                return;
            }
            Assert.Fail("No exception was thrown");
        }
    }
}
