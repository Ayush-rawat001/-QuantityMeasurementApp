using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurmentApp.Models;
using QuantityMeasurmentApp.Services;

namespace QuantityMeasurementAppTest
{
    [TestClass]
    public class QuantityLengthTests
    {
        private MeasurementService service;

        [TestInitialize]
        public void Setup()
        {
            service = new MeasurementService();
        }

        // testEquality_FeetToFeet_SameValue
        [TestMethod]
        public void GivenSameFeetValues_WhenCompared_ShouldReturnTrue()
        {
            QuantityLength q1 = new QuantityLength(1.0, LengthUnit.Feet);
            QuantityLength q2 = new QuantityLength(1.0, LengthUnit.Feet);

            bool result = service.AreEqual(q1, q2);

            Assert.IsTrue(result);
        }

        // testEquality_InchToInch_SameValue
        [TestMethod]
        public void GivenSameInchValues_WhenCompared_ShouldReturnTrue()
        {
            QuantityLength q1 = new QuantityLength(1.0, LengthUnit.Inches);
            QuantityLength q2 = new QuantityLength(1.0, LengthUnit.Inches);

            bool result = service.AreEqual(q1, q2);

            Assert.IsTrue(result);
        }

        // testEquality_FeetToInch_EquivalentValue
        [TestMethod]
        public void GivenOneFeetAndTwelveInches_WhenCompared_ShouldReturnTrue()
        {
            QuantityLength q1 = new QuantityLength(1.0, LengthUnit.Feet);
            QuantityLength q2 = new QuantityLength(12.0, LengthUnit.Inches);

            bool result = service.AreEqual(q1, q2);

            Assert.IsTrue(result);
        }

        // testEquality_InchToFeet_EquivalentValue
        [TestMethod]
        public void GivenTwelveInchesAndOneFeet_WhenCompared_ShouldReturnTrue()
        {
            QuantityLength q1 = new QuantityLength(12.0, LengthUnit.Inches);
            QuantityLength q2 = new QuantityLength(1.0, LengthUnit.Feet);

            bool result = service.AreEqual(q1, q2);

            Assert.IsTrue(result);
        }

        // testEquality_FeetToFeet_DifferentValue
        [TestMethod]
        public void GivenDifferentFeetValues_WhenCompared_ShouldReturnFalse()
        {
            QuantityLength q1 = new QuantityLength(1.0, LengthUnit.Feet);
            QuantityLength q2 = new QuantityLength(2.0, LengthUnit.Feet);

            bool result = service.AreEqual(q1, q2);

            Assert.IsFalse(result);
        }

        // testEquality_InchToInch_DifferentValue
        [TestMethod]
        public void GivenDifferentInchValues_WhenCompared_ShouldReturnFalse()
        {
            QuantityLength q1 = new QuantityLength(1.0, LengthUnit.Inches);
            QuantityLength q2 = new QuantityLength(2.0, LengthUnit.Inches);

            bool result = service.AreEqual(q1, q2);

            Assert.IsFalse(result);
        }

        // testEquality_NullComparison
        [TestMethod]
        public void GivenNull_WhenCompared_ShouldReturnFalse()
        {
            QuantityLength q1 = new QuantityLength(1.0, LengthUnit.Feet);
            QuantityLength q2 = null;

            bool result = service.AreEqual(q1, q2);

            Assert.IsFalse(result);
        }

        // testEquality_SameReference
        [TestMethod]
        public void GivenSameReference_WhenCompared_ShouldReturnTrue()
        {
            QuantityLength q1 = new QuantityLength(1.0, LengthUnit.Feet);

            bool result = service.AreEqual(q1, q1);

            Assert.IsTrue(result);
        }

        // Reflexive property
        [TestMethod]
        public void Equals_ShouldBeReflexive()
        {
            QuantityLength q = new QuantityLength(5.0, LengthUnit.Feet);

            Assert.IsTrue(q.Equals(q));
        }

        // Symmetric property
        [TestMethod]
        public void Equals_ShouldBeSymmetric()
        {
            QuantityLength a = new QuantityLength(1.0, LengthUnit.Feet);
            QuantityLength b = new QuantityLength(12.0, LengthUnit.Inches);

            Assert.IsTrue(a.Equals(b));
            Assert.IsTrue(b.Equals(a));
        }

        // Transitive property
        [TestMethod]
        public void Equals_ShouldBeTransitive()
        {
            QuantityLength a = new QuantityLength(1.0, LengthUnit.Feet);
            QuantityLength b = new QuantityLength(12.0, LengthUnit.Inches);
            QuantityLength c = new QuantityLength(1.0, LengthUnit.Feet);

            Assert.IsTrue(a.Equals(b));
            Assert.IsTrue(b.Equals(c));
            Assert.IsTrue(a.Equals(c));
        }

        // Consistency
        [TestMethod]
        public void Equals_ShouldBeConsistent()
        {
            QuantityLength a = new QuantityLength(1.0, LengthUnit.Feet);
            QuantityLength b = new QuantityLength(12.0, LengthUnit.Inches);

            Assert.IsTrue(a.Equals(b));
            Assert.IsTrue(a.Equals(b));
            Assert.IsTrue(a.Equals(b));
        }
    }
}