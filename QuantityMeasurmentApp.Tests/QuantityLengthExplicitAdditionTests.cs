using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurmentApp.Models;

namespace QuantityMeasurmentApp.Tests
{
    [TestClass]
    public class QuantityLengthExplicitAdditionTests
    {
        private const double EPSILON = 0.001;

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_Feet()
        {
            var q1 = new QuantityLength(1.0, LengthUnit.Feet);
            var q2 = new QuantityLength(12.0, LengthUnit.Inches);

            var result = q1.Add(q2, LengthUnit.Feet);

            Assert.AreEqual(2.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_Inches()
        {
            var q1 = new QuantityLength(1.0, LengthUnit.Feet);
            var q2 = new QuantityLength(12.0, LengthUnit.Inches);

            var result = q1.Add(q2, LengthUnit.Inches);

            Assert.AreEqual(24.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_Yards()
        {
            var q1 = new QuantityLength(1.0, LengthUnit.Feet);
            var q2 = new QuantityLength(12.0, LengthUnit.Inches);

            var result = q1.Add(q2, LengthUnit.Yards);

            Assert.IsTrue(System.Math.Abs(result.Value - 0.667) < EPSILON);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_Centimeters()
        {
            var q1 = new QuantityLength(1.0, LengthUnit.Inches);
            var q2 = new QuantityLength(1.0, LengthUnit.Inches);

            var result = q1.Add(q2, LengthUnit.Centimeters);

            Assert.IsTrue(System.Math.Abs(result.Value - 5.08) < EPSILON);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_SameAsFirstOperand()
        {
            var q1 = new QuantityLength(2.0, LengthUnit.Yards);
            var q2 = new QuantityLength(3.0, LengthUnit.Feet);

            var result = q1.Add(q2, LengthUnit.Yards);

            Assert.AreEqual(3.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_SameAsSecondOperand()
        {
            var q1 = new QuantityLength(2.0, LengthUnit.Yards);
            var q2 = new QuantityLength(3.0, LengthUnit.Feet);

            var result = q1.Add(q2, LengthUnit.Feet);

            Assert.AreEqual(9.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_Commutativity()
        {
            var a = new QuantityLength(1.0, LengthUnit.Feet);
            var b = new QuantityLength(12.0, LengthUnit.Inches);

            var r1 = a.Add(b, LengthUnit.Yards);
            var r2 = b.Add(a, LengthUnit.Yards);

            Assert.AreEqual(r1.Value, r2.Value, EPSILON);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_WithZero()
        {
            var a = new QuantityLength(5.0, LengthUnit.Feet);
            var b = new QuantityLength(0.0, LengthUnit.Inches);

            var result = a.Add(b, LengthUnit.Yards);

            Assert.IsTrue(System.Math.Abs(result.Value - 1.667) < EPSILON);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_NegativeValues()
        {
            var a = new QuantityLength(5.0, LengthUnit.Feet);
            var b = new QuantityLength(-2.0, LengthUnit.Feet);

            var result = a.Add(b, LengthUnit.Inches);

            Assert.AreEqual(36.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_NullSecondOperand()
        {
            try
            {
                var q1 = new QuantityLength(1.0, LengthUnit.Feet);
                QuantityLength q2 = null;

                q1.Add(q2, LengthUnit.Feet);

                Assert.Fail("Exception expected");
            }
            catch (System.ArgumentException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_LargeToSmallScale()
        {
            var q1 = new QuantityLength(1000.0, LengthUnit.Feet);
            var q2 = new QuantityLength(500.0, LengthUnit.Feet);

            var result = q1.Add(q2, LengthUnit.Inches);

            Assert.AreEqual(18000.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_SmallToLargeScale()
        {
            var q1 = new QuantityLength(12.0, LengthUnit.Inches);
            var q2 = new QuantityLength(12.0, LengthUnit.Inches);

            var result = q1.Add(q2, LengthUnit.Yards);

            Assert.IsTrue(System.Math.Abs(result.Value - 0.667) < EPSILON);
        }
    }
}