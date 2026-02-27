using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurmentApp.Models;
using QuantityMeasurmentApp.Services;

namespace QuantityMeasurementAppTest
{
    [TestClass]
    public class FeetTests
    {
        private MeasurementService service;

        [TestInitialize]
        public void Setup()
        {
            service = new MeasurementService();
        }

        // testEquality_SameValue
        [TestMethod]
        public void GivenSameFeetValues_WhenCompared_ShouldReturnTrue()
        {
            Feet f1 = new Feet(1.0);
            Feet f2 = new Feet(1.0);

            bool result = service.AreEqual(f1, f2);

            Assert.IsTrue(result, "Expected values to be equal but they were not.");
        }

        // testEquality_DifferentValue
        [TestMethod]
        public void GivenDifferentFeetValues_WhenCompared_ShouldReturnFalse()
        {
            Feet f1 = new Feet(1.0);
            Feet f2 = new Feet(2.0);

            bool result = service.AreEqual(f1, f2);

            Assert.IsFalse(result, "Expected values to be different but they were equal.");
        }

        // testEquality_NullComparison
        [TestMethod]
        public void GivenNullValue_WhenCompared_ShouldReturnFalse()
        {
            Feet f1 = new Feet(1.0);
            Feet f2 = null;

            bool result = service.AreEqual(f1, f2);

            Assert.IsFalse(result, "Comparison with null should return false.");
        }

        // testEquality_SameReference
        [TestMethod]
        public void GivenSameReference_WhenCompared_ShouldReturnTrue()
        {
            Feet f1 = new Feet(3.5);

            bool result = service.AreEqual(f1, f1);

            Assert.IsTrue(result, "Same object reference must be equal.");
        }

        // testEquality_NonNumericInput (handled via object comparison)
        [TestMethod]
        public void GivenDifferentTypeObject_WhenCompared_ShouldReturnFalse()
        {
            Feet f1 = new Feet(1.0);
            object other = "Not a Feet object";

            bool result = f1.Equals(other);

            Assert.IsFalse(result, "Feet object should not equal non-Feet object.");
        }

        // Reflexive property
        [TestMethod]
        public void Equals_ShouldBeReflexive()
        {
            Feet f = new Feet(5.0);

            Assert.IsTrue(f.Equals(f));
        }

        // Symmetric property
        [TestMethod]
        public void Equals_ShouldBeSymmetric()
        {
            Feet a = new Feet(2.0);
            Feet b = new Feet(2.0);

            Assert.IsTrue(a.Equals(b));
            Assert.IsTrue(b.Equals(a));
        }

        // Transitive property
        [TestMethod]
        public void Equals_ShouldBeTransitive()
        {
            Feet a = new Feet(4.0);
            Feet b = new Feet(4.0);
            Feet c = new Feet(4.0);

            Assert.IsTrue(a.Equals(b));
            Assert.IsTrue(b.Equals(c));
            Assert.IsTrue(a.Equals(c));
        }

        // Consistency property
        [TestMethod]
        public void Equals_ShouldBeConsistent()
        {
            Feet a = new Feet(6.0);
            Feet b = new Feet(6.0);

            Assert.IsTrue(a.Equals(b));
            Assert.IsTrue(a.Equals(b));
            Assert.IsTrue(a.Equals(b));
        }
    }
}