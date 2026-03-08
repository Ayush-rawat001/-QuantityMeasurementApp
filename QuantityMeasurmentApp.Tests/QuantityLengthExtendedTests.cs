using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurmentApp.Models;

namespace QuantityMeasurmentApp.Tests
{
    [TestClass]
    public class QuantityLengthExtendedTests
    {
        [TestMethod]
        public void testEquality_YardToYard_SameValue()
        {
            var q1 = new QuantityLength(1.0, LengthUnit.Yards);
            var q2 = new QuantityLength(1.0, LengthUnit.Yards);

            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void testEquality_YardToYard_DifferentValue()
        {
            var q1 = new QuantityLength(1.0, LengthUnit.Yards);
            var q2 = new QuantityLength(2.0, LengthUnit.Yards);

            Assert.IsFalse(q1.Equals(q2));
        }

        [TestMethod]
        public void testEquality_YardToFeet_EquivalentValue()
        {
            var yard = new QuantityLength(1.0, LengthUnit.Yards);
            var feet = new QuantityLength(3.0, LengthUnit.Feet);

            Assert.IsTrue(yard.Equals(feet));
        }

        [TestMethod]
        public void testEquality_FeetToYard_EquivalentValue()
        {
            var feet = new QuantityLength(3.0, LengthUnit.Feet);
            var yard = new QuantityLength(1.0, LengthUnit.Yards);

            Assert.IsTrue(feet.Equals(yard));
        }

        [TestMethod]
        public void testEquality_YardToInches_EquivalentValue()
        {
            var yard = new QuantityLength(1.0, LengthUnit.Yards);
            var inches = new QuantityLength(36.0, LengthUnit.Inches);

            Assert.IsTrue(yard.Equals(inches));
        }

        [TestMethod]
        public void testEquality_InchesToYard_EquivalentValue()
        {
            var inches = new QuantityLength(36.0, LengthUnit.Inches);
            var yard = new QuantityLength(1.0, LengthUnit.Yards);

            Assert.IsTrue(inches.Equals(yard));
        }

        [TestMethod]
        public void testEquality_YardToFeet_NonEquivalentValue()
        {
            var yard = new QuantityLength(1.0, LengthUnit.Yards);
            var feet = new QuantityLength(2.0, LengthUnit.Feet);

            Assert.IsFalse(yard.Equals(feet));
        }

        [TestMethod]
        public void testEquality_centimetersToInches_EquivalentValue()
        {
            var cm = new QuantityLength(1.0, LengthUnit.Centimeters);
            var inches = new QuantityLength(0.393701, LengthUnit.Inches);

            Assert.IsTrue(cm.Equals(inches));
        }

        [TestMethod]
        public void testEquality_centimetersToFeet_NonEquivalentValue()
        {
            var cm = new QuantityLength(1.0, LengthUnit.Centimeters);
            var feet = new QuantityLength(1.0, LengthUnit.Feet);

            Assert.IsFalse(cm.Equals(feet));
        }

        [TestMethod]
        public void testEquality_MultiUnit_TransitiveProperty()
        {
            var yard = new QuantityLength(1.0, LengthUnit.Yards);
            var feet = new QuantityLength(3.0, LengthUnit.Feet);
            var inches = new QuantityLength(36.0, LengthUnit.Inches);

            Assert.IsTrue(yard.Equals(feet));
            Assert.IsTrue(feet.Equals(inches));
            Assert.IsTrue(yard.Equals(inches));
        }

        [TestMethod]
        public void testEquality_YardSameReference()
        {
            var yard = new QuantityLength(1.0, LengthUnit.Yards);

            Assert.IsTrue(yard.Equals(yard));
        }

        [TestMethod]
        public void testEquality_YardNullComparison()
        {
            var yard = new QuantityLength(1.0, LengthUnit.Yards);

            Assert.IsFalse(yard.Equals(null));
        }

        [TestMethod]
        public void testEquality_CentimetersSameReference()
        {
            var cm = new QuantityLength(5.0, LengthUnit.Centimeters);

            Assert.IsTrue(cm.Equals(cm));
        }

        [TestMethod]
        public void testEquality_CentimetersNullComparison()
        {
            var cm = new QuantityLength(5.0, LengthUnit.Centimeters);

            Assert.IsFalse(cm.Equals(null));
        }

        [TestMethod]
        public void testEquality_AllUnits_ComplexScenario()
        {
            var yard = new QuantityLength(2.0, LengthUnit.Yards);
            var feet = new QuantityLength(6.0, LengthUnit.Feet);
            var inches = new QuantityLength(72.0, LengthUnit.Inches);

            Assert.IsTrue(yard.Equals(feet));
            Assert.IsTrue(feet.Equals(inches));
            Assert.IsTrue(yard.Equals(inches));
        }
    }
}