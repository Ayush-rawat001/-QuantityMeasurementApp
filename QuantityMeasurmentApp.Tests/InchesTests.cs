using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurmentApp.Models;
using QuantityMeasurmentApp.Services;

namespace QuantityMeasurementAppTest
{
    [TestClass]
    public class InchesTests
    {
        private MeasurementService service;

        [TestInitialize]
        public void Setup()
        {
            service = new MeasurementService();
        }

        // testEquality_SameValue
        [TestMethod]
        public void GivenSameInchesValues_WhenCompared_ShouldReturnTrue()
        {
            Inches i1 = new Inches(1.0);
            Inches i2 = new Inches(1.0);

            bool result = service.AreEqual(i1, i2);

            Assert.IsTrue(result, "Expected values to be equal but they were not.");
        }

        // testEquality_DifferentValue
        [TestMethod]
        public void GivenDifferentInchesValues_WhenCompared_ShouldReturnFalse()
        {
            Inches i1 = new Inches(1.0);
            Inches i2 = new Inches(2.0);

            bool result = service.AreEqual(i1, i2);

            Assert.IsFalse(result, "Expected values to be different but they were equal.");
        }

        // testEquality_NullComparison
        [TestMethod]
        public void GivenNullValue_WhenCompared_ShouldReturnFalse()
        {
            Inches i1 = new Inches(1.0);
            Inches i2 = null;

            bool result = service.AreEqual(i1, i2);

            Assert.IsFalse(result, "Comparison with null should return false.");
        }

        // testEquality_SameReference
        [TestMethod]
        public void GivenSameReference_WhenCompared_ShouldReturnTrue()
        {
            Inches i1 = new Inches(3.5);

            bool result = service.AreEqual(i1, i1);

            Assert.IsTrue(result, "Same object reference must be equal.");
        }

        // testEquality_NonNumericInput
        [TestMethod]
        public void GivenDifferentTypeObject_WhenCompared_ShouldReturnFalse()
        {
            Inches i1 = new Inches(1.0);
            object other = "Not an Inches object";

            bool result = i1.Equals(other);

            Assert.IsFalse(result, "Inches object should not equal non-Inches object.");
        }

        // Reflexive property
        [TestMethod]
        public void Equals_ShouldBeReflexive()
        {
            Inches i = new Inches(5.0);

            Assert.IsTrue(i.Equals(i));
        }

        // Symmetric property
        [TestMethod]
        public void Equals_ShouldBeSymmetric()
        {
            Inches a = new Inches(2.0);
            Inches b = new Inches(2.0);

            Assert.IsTrue(a.Equals(b));
            Assert.IsTrue(b.Equals(a));
        }

        // Transitive property
        [TestMethod]
        public void Equals_ShouldBeTransitive()
        {
            Inches a = new Inches(4.0);
            Inches b = new Inches(4.0);
            Inches c = new Inches(4.0);

            Assert.IsTrue(a.Equals(b));
            Assert.IsTrue(b.Equals(c));
            Assert.IsTrue(a.Equals(c));
        }

        // Consistency property
        [TestMethod]
        public void Equals_ShouldBeConsistent()
        {
            Inches a = new Inches(6.0);
            Inches b = new Inches(6.0);

            Assert.IsTrue(a.Equals(b));
            Assert.IsTrue(a.Equals(b));
            Assert.IsTrue(a.Equals(b));
        }
    }
}