using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurmentApp.Models;

namespace QuantityMeasurmentApp.Tests
{
    [TestClass]
    public class QuantityLengthAdditionTests
    {
        private const double EPSILON = 0.0001;

        [TestMethod]
        public void testAddition_SameUnit_FeetPlusFeet()
        {
            var q1 = new QuantityLength(1.0, LengthUnit.Feet);
            var q2 = new QuantityLength(2.0, LengthUnit.Feet);

            var result = q1.Add(q2);

            Assert.AreEqual(3.0, result.Value, EPSILON);
            Assert.AreEqual(LengthUnit.Feet, result.Unit);
        }

        [TestMethod]
        public void testAddition_SameUnit_InchPlusInch()
        {
            var q1 = new QuantityLength(6.0, LengthUnit.Inches);
            var q2 = new QuantityLength(6.0, LengthUnit.Inches);

            var result = q1.Add(q2);

            Assert.AreEqual(12.0, result.Value, EPSILON);
            Assert.AreEqual(LengthUnit.Inches, result.Unit);
        }

        [TestMethod]
        public void testAddition_CrossUnit_FeetPlusInches()
        {
            var q1 = new QuantityLength(1.0, LengthUnit.Feet);
            var q2 = new QuantityLength(12.0, LengthUnit.Inches);

            var result = q1.Add(q2);

            Assert.AreEqual(2.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testAddition_CrossUnit_InchPlusFeet()
        {
            var q1 = new QuantityLength(12.0, LengthUnit.Inches);
            var q2 = new QuantityLength(1.0, LengthUnit.Feet);

            var result = q1.Add(q2);

            Assert.AreEqual(24.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testAddition_CrossUnit_YardPlusFeet()
        {
            var q1 = new QuantityLength(1.0, LengthUnit.Yards);
            var q2 = new QuantityLength(3.0, LengthUnit.Feet);

            var result = q1.Add(q2);

            Assert.AreEqual(2.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testAddition_CrossUnit_CentimeterPlusInch()
        {
            var q1 = new QuantityLength(2.54, LengthUnit.Centimeters);
            var q2 = new QuantityLength(1.0, LengthUnit.Inches);

            var result = q1.Add(q2);

            Assert.IsTrue(System.Math.Abs(result.Value - 5.08) < EPSILON);
        }

        [TestMethod]
        public void testAddition_Commutativity()
        {
            var q1 = new QuantityLength(1.0, LengthUnit.Feet);
            var q2 = new QuantityLength(12.0, LengthUnit.Inches);

            var result1 = q1.Add(q2);
            var result2 = q2.Add(q1);

            double r1 = QuantityLength.Convert(result1.Value, result1.Unit, LengthUnit.Feet);
            double r2 = QuantityLength.Convert(result2.Value, result2.Unit, LengthUnit.Feet);

            Assert.AreEqual(r1, r2, EPSILON);
        }

        [TestMethod]
        public void testAddition_WithZero()
        {
            var q1 = new QuantityLength(5.0, LengthUnit.Feet);
            var q2 = new QuantityLength(0.0, LengthUnit.Inches);

            var result = q1.Add(q2);

            Assert.AreEqual(5.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testAddition_NegativeValues()
        {
            var q1 = new QuantityLength(5.0, LengthUnit.Feet);
            var q2 = new QuantityLength(-2.0, LengthUnit.Feet);

            var result = q1.Add(q2);

            Assert.AreEqual(3.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testAddition_NullSecondOperand()
        {
            try
            {
                var q1 = new QuantityLength(1.0, LengthUnit.Feet);
                QuantityLength q2 = null;

                q1.Add(q2);

                Assert.Fail("Expected exception was not thrown");
            }
            catch (System.ArgumentException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void testAddition_LargeValues()
        {
            var q1 = new QuantityLength(1e6, LengthUnit.Feet);
            var q2 = new QuantityLength(1e6, LengthUnit.Feet);

            var result = q1.Add(q2);

            Assert.AreEqual(2e6, result.Value, EPSILON);
        }

        [TestMethod]
        public void testAddition_SmallValues()
        {
            var q1 = new QuantityLength(0.001, LengthUnit.Feet);
            var q2 = new QuantityLength(0.002, LengthUnit.Feet);

            var result = q1.Add(q2);

            Assert.IsTrue(System.Math.Abs(result.Value - 0.003) < EPSILON);
        }
    }
}