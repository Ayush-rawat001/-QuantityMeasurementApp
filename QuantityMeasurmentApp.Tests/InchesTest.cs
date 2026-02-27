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
        public void GivenSameInchValues_WhenCompared_ShouldReturnTrue()
        {
            Inches i1 = new Inches(1.0);
            Inches i2 = new Inches(1.0);

            bool result = service.AreEqual(i1, i2);

            Assert.IsTrue(result);
        }

        // testEquality_DifferentValue
        [TestMethod]
        public void GivenDifferentInchValues_WhenCompared_ShouldReturnFalse()
        {
            Inches i1 = new Inches(1.0);
            Inches i2 = new Inches(2.0);

            bool result = service.AreEqual(i1, i2);

            Assert.IsFalse(result);
        }

        // testEquality_NullComparison
        [TestMethod]
        public void GivenNullValue_WhenCompared_ShouldReturnFalse()
        {
            Inches i1 = new Inches(1.0);
            Inches i2 = null;

            bool result = service.AreEqual(i1, i2);

            Assert.IsFalse(result);
        }

        // testEquality_SameReference
        [TestMethod]
        public void GivenSameReference_WhenCompared_ShouldReturnTrue()
        {
            Inches i = new Inches(3.5);

            bool result = service.AreEqual(i, i);

            Assert.IsTrue(result);
        }

        // testEquality_NonNumericInput
        [TestMethod]
        public void GivenDifferentTypeObject_WhenCompared_ShouldReturnFalse()
        {
            Inches i = new Inches(1.0);
            object other = "Not Inches";

            bool result = i.Equals(other);

            Assert.IsFalse(result);
        }

        // Reflexive
        [TestMethod]
        public void Equals_ShouldBeReflexive()
        {
            Inches i = new Inches(5.0);

            Assert.IsTrue(i.Equals(i));
        }

        // Symmetric
        [TestMethod]
        public void Equals_ShouldBeSymmetric()
        {
            Inches a = new Inches(2.0);
            Inches b = new Inches(2.0);

            Assert.IsTrue(a.Equals(b));
            Assert.IsTrue(b.Equals(a));
        }

        // Transitive
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

        // Consistency
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