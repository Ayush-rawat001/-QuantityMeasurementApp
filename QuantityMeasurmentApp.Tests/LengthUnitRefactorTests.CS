using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurmentApp.Models;
using System;

namespace QuantityMeasurmentApp.Tests
{
    [TestClass]
    public class LengthUnitRefactorTests
    {
        private const double EPSILON = 0.0001;

        // ---------- ENUM CONSTANT TESTS ----------

        [TestMethod]
        public void testLengthUnitEnum_FeetConstant()
        {
            double factor = LengthUnit.Feet.GetConversionFactor();
            Assert.AreEqual(1.0, factor, EPSILON);
        }

        [TestMethod]
        public void testLengthUnitEnum_InchesConstant()
        {
            double factor = LengthUnit.Inches.GetConversionFactor();
            Assert.AreEqual(1.0 / 12.0, factor, EPSILON);
        }

        [TestMethod]
        public void testLengthUnitEnum_YardsConstant()
        {
            double factor = LengthUnit.Yards.GetConversionFactor();
            Assert.AreEqual(3.0, factor, EPSILON);
        }

        [TestMethod]
        public void testLengthUnitEnum_CentimetersConstant()
        {
            double factor = LengthUnit.Centimeters.GetConversionFactor();
            Assert.AreEqual(1.0 / 30.48, factor, EPSILON);
        }

        // ---------- CONVERT TO BASE UNIT ----------

        [TestMethod]
        public void testConvertToBaseUnit_FeetToFeet()
        {
            double result = LengthUnit.Feet.ConvertToBaseUnit(5.0);
            Assert.AreEqual(5.0, result, EPSILON);
        }

        [TestMethod]
        public void testConvertToBaseUnit_InchesToFeet()
        {
            double result = LengthUnit.Inches.ConvertToBaseUnit(12.0);
            Assert.AreEqual(1.0, result, EPSILON);
        }

        [TestMethod]
        public void testConvertToBaseUnit_YardsToFeet()
        {
            double result = LengthUnit.Yards.ConvertToBaseUnit(1.0);
            Assert.AreEqual(3.0, result, EPSILON);
        }

        [TestMethod]
        public void testConvertToBaseUnit_CentimetersToFeet()
        {
            double result = LengthUnit.Centimeters.ConvertToBaseUnit(30.48);
            Assert.AreEqual(1.0, result, EPSILON);
        }

        // ---------- CONVERT FROM BASE UNIT ----------

        [TestMethod]
        public void testConvertFromBaseUnit_FeetToFeet()
        {
            double result = LengthUnit.Feet.ConvertFromBaseUnit(2.0);
            Assert.AreEqual(2.0, result, EPSILON);
        }

        [TestMethod]
        public void testConvertFromBaseUnit_FeetToInches()
        {
            double result = LengthUnit.Inches.ConvertFromBaseUnit(1.0);
            Assert.AreEqual(12.0, result, EPSILON);
        }

        [TestMethod]
        public void testConvertFromBaseUnit_FeetToYards()
        {
            double result = LengthUnit.Yards.ConvertFromBaseUnit(3.0);
            Assert.AreEqual(1.0, result, EPSILON);
        }

        [TestMethod]
        public void testConvertFromBaseUnit_FeetToCentimeters()
        {
            double result = LengthUnit.Centimeters.ConvertFromBaseUnit(1.0);
            Assert.AreEqual(30.48, result, EPSILON);
        }

        // ---------- QUANTITYLENGTH TESTS ----------

        [TestMethod]
        public void testQuantityLengthRefactored_Equality()
        {
            QuantityLength a = new QuantityLength(1.0, LengthUnit.Feet);
            QuantityLength b = new QuantityLength(12.0, LengthUnit.Inches);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testQuantityLengthRefactored_ConvertTo()
        {
            QuantityLength a = new QuantityLength(1.0, LengthUnit.Feet);

            QuantityLength result = a.ConvertTo(LengthUnit.Inches);

            Assert.AreEqual(12.0, result.Value, EPSILON);
            Assert.AreEqual(LengthUnit.Inches, result.Unit);
        }

        [TestMethod]
        public void testQuantityLengthRefactored_Add()
        {
            QuantityLength a = new QuantityLength(1.0, LengthUnit.Feet);
            QuantityLength b = new QuantityLength(12.0, LengthUnit.Inches);

            QuantityLength result = a.Add(b, LengthUnit.Feet);

            Assert.AreEqual(2.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testQuantityLengthRefactored_AddWithTargetUnit()
        {
            QuantityLength a = new QuantityLength(1.0, LengthUnit.Feet);
            QuantityLength b = new QuantityLength(12.0, LengthUnit.Inches);

            QuantityLength result = a.Add(b, LengthUnit.Yards);

            Assert.AreEqual(0.6666, result.Value, 0.01);
        }

        // ---------- INVALID INPUT TEST ----------

        [TestMethod]
        public void testQuantityLengthRefactored_InvalidValue()
        {
            try
            {
                QuantityLength q = new QuantityLength(double.NaN, LengthUnit.Feet);
                Assert.Fail("Expected exception was not thrown");
            }
            catch (ArgumentException)
            {
                Assert.IsTrue(true);
            }
        }

        // ---------- ROUND TRIP TEST ----------

        [TestMethod]
        public void testRoundTripConversion_RefactoredDesign()
        {
            double value = 10;

            double inches = LengthUnit.Inches.ConvertFromBaseUnit(
                LengthUnit.Feet.ConvertToBaseUnit(value));

            double feet = LengthUnit.Feet.ConvertFromBaseUnit(
                LengthUnit.Inches.ConvertToBaseUnit(inches));

            Assert.AreEqual(value, feet, EPSILON);
        }

        // ---------- UNIT IMMUTABILITY ----------

        [TestMethod]
        public void testUnitImmutability()
        {
            LengthUnit unit = LengthUnit.Feet;

            Assert.AreEqual(LengthUnit.Feet, unit);
        }
    }
}