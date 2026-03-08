using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurmentApp.Models;
using System;

namespace QuantityMeasurmentApp.Tests
{
    [TestClass]
    public class QuantityLengthConversionTests
    {
        private const double EPSILON = 1e-6;


        [TestMethod]
        public void testConversion_FeetToInches()
        {
            double result = QuantityLength.Convert(1.0, LengthUnit.Feet, LengthUnit.Inches);
            Assert.AreEqual(12.0, result, EPSILON);
        }

        [TestMethod]
        public void testConversion_InchesToFeet()
        {
            double result = QuantityLength.Convert(24.0, LengthUnit.Inches, LengthUnit.Feet);
            Assert.AreEqual(2.0, result, EPSILON);
        }

        [TestMethod]
        public void testConversion_YardsToInches()
        {
            double result = QuantityLength.Convert(1.0, LengthUnit.Yards, LengthUnit.Inches);
            Assert.AreEqual(36.0, result, EPSILON);
        }

        [TestMethod]
        public void testConversion_InchesToYards()
        {
            double result = QuantityLength.Convert(72.0, LengthUnit.Inches, LengthUnit.Yards);
            Assert.AreEqual(2.0, result, EPSILON);
        }

        [TestMethod]
        public void testConversion_CentimetersToInches()
        {
            double result = QuantityLength.Convert(2.54, LengthUnit.Centimeters, LengthUnit.Inches);
            Assert.AreEqual(1.0, result, EPSILON);
        }

        [TestMethod]
        public void testConversion_FeatToYard()
        {
            double result = QuantityLength.Convert(6.0, LengthUnit.Feet, LengthUnit.Yards);
            Assert.AreEqual(2.0, result, EPSILON);
        }

        [TestMethod]
        public void testConversion_RoundTrip_PreservesValue()
        {
            double value = 5.0;

            double converted = QuantityLength.Convert(value, LengthUnit.Feet, LengthUnit.Inches);
            double back = QuantityLength.Convert(converted, LengthUnit.Inches, LengthUnit.Feet);

            Assert.AreEqual(value, back, EPSILON);
        }

        [TestMethod]
        public void testConversion_ZeroValue()
        {
            double result = QuantityLength.Convert(0.0, LengthUnit.Feet, LengthUnit.Inches);
            Assert.AreEqual(0.0, result, EPSILON);
        }

        [TestMethod]
        public void testConversion_NegativeValue()
        {
            double result = QuantityLength.Convert(-1.0, LengthUnit.Feet, LengthUnit.Inches);
            Assert.AreEqual(-12.0, result, EPSILON);
        }

        [TestMethod]
        public void testConversion_InvalidUnit_Throws()
        {
            try
            {
                QuantityLength.Convert(1.0, LengthUnit.Feet, (LengthUnit)(-1));
                Assert.Fail("Expected ArgumentException was not thrown");
            }
            catch (ArgumentException)
            {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void testConversion_NaNOrInfinite_Throws()
        {
            try
            {
                QuantityLength.Convert(double.NaN, LengthUnit.Feet, LengthUnit.Inches);
                Assert.Fail("Expected ArgumentException was not thrown");
            }
            catch (ArgumentException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void testConversion_PrecisionTolerance()
        {
            double result = QuantityLength.Convert(1.0, LengthUnit.Centimeters, LengthUnit.Inches);
            Assert.IsTrue(Math.Abs(result - 0.393701) < EPSILON);
        }
    }


}
