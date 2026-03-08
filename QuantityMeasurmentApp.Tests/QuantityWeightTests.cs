using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurmentApp.Models;
using System;

namespace QuantityMeasurmentApp.Tests
{
    [TestClass]
    public class QuantityWeightTests
    {
        private const double Epsilon = 0.0001;

        // ---------- EQUALITY TESTS ----------
        [TestMethod]
        public void testEquality_KilogramToKilogram_SameValue()
        {
            var q1 = new QuantityWeight(1.0, WeightUnit.Kilogram);
            var q2 = new QuantityWeight(1.0, WeightUnit.Kilogram);
            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void testEquality_KilogramToKilogram_DifferentValue()
        {
            var q1 = new QuantityWeight(1.0, WeightUnit.Kilogram);
            var q2 = new QuantityWeight(2.0, WeightUnit.Kilogram);
            Assert.IsFalse(q1.Equals(q2));
        }

        [TestMethod]
        public void testEquality_KilogramToGram_EquivalentValue()
        {
            var q1 = new QuantityWeight(1.0, WeightUnit.Kilogram);
            var q2 = new QuantityWeight(1000.0, WeightUnit.Gram);
            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void testEquality_GramToKilogram_EquivalentValue()
        {
            var q1 = new QuantityWeight(1000.0, WeightUnit.Gram);
            var q2 = new QuantityWeight(1.0, WeightUnit.Kilogram);
            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void testEquality_PoundToKilogram()
        {
            var q1 = new QuantityWeight(2.20462, WeightUnit.Pound);
            var q2 = new QuantityWeight(1.0, WeightUnit.Kilogram);
            Assert.IsTrue(Math.Abs(q1.ConvertTo(WeightUnit.Kilogram).Value - q2.Value) < Epsilon);
        }

        [TestMethod]
        public void testEquality_WeightVsLength_Incompatible()
        {
            var weight = new QuantityWeight(1.0, WeightUnit.Kilogram);
            var length = new QuantityLength(1.0, LengthUnit.Feet);
            Assert.IsFalse(weight.Equals(length));
        }

        [TestMethod]
        public void testEquality_NullComparison()
        {
            var weight = new QuantityWeight(1.0, WeightUnit.Kilogram);
            QuantityWeight? nullWeight = null;
            Assert.IsFalse(weight.Equals(nullWeight));
        }

        [TestMethod]
        public void testEquality_SameReference()
        {
            var weight = new QuantityWeight(1.0, WeightUnit.Kilogram);
            Assert.IsTrue(weight.Equals(weight));
        }

       
        // ---------- CONVERSION TESTS ----------
        [TestMethod]
        public void testConversion_KilogramToGram()
        {
            var weight = new QuantityWeight(1.0, WeightUnit.Kilogram);
            var converted = weight.ConvertTo(WeightUnit.Gram);
            Assert.AreEqual(1000.0, converted.Value, Epsilon);
            Assert.AreEqual(WeightUnit.Gram, converted.Unit);
        }

        [TestMethod]
        public void testConversion_GramToKilogram()
        {
            var weight = new QuantityWeight(1000.0, WeightUnit.Gram);
            var converted = weight.ConvertTo(WeightUnit.Kilogram);
            Assert.AreEqual(1.0, converted.Value, Epsilon);
            Assert.AreEqual(WeightUnit.Kilogram, converted.Unit);
        }

        [TestMethod]
        public void testConversion_KilogramToPound()
        {
            var weight = new QuantityWeight(1.0, WeightUnit.Kilogram);
            var converted = weight.ConvertTo(WeightUnit.Pound);
            Assert.AreEqual(2.20462, converted.Value, 1e-5);
        }

        [TestMethod]
        public void testConversion_PoundToKilogram()
        {
            var weight = new QuantityWeight(2.20462, WeightUnit.Pound);
            var converted = weight.ConvertTo(WeightUnit.Kilogram);
            Assert.AreEqual(1.0, converted.Value, 1e-5);
        }

        [TestMethod]
        public void testConversion_RoundTrip()
        {
            var weight = new QuantityWeight(1.5, WeightUnit.Kilogram);
            var converted = weight.ConvertTo(WeightUnit.Gram).ConvertTo(WeightUnit.Kilogram);
            Assert.AreEqual(1.5, converted.Value, Epsilon);
        }

        [TestMethod]
        public void testConversion_NegativeValue()
        {
            var weight = new QuantityWeight(-1.0, WeightUnit.Kilogram);
            var converted = weight.ConvertTo(WeightUnit.Gram);
            Assert.AreEqual(-1000.0, converted.Value, Epsilon);
        }

        [TestMethod]
        public void testConversion_ZeroValue()
        {
            var weight = new QuantityWeight(0.0, WeightUnit.Kilogram);
            var converted = weight.ConvertTo(WeightUnit.Gram);
            Assert.AreEqual(0.0, converted.Value, Epsilon);
        }

        // ---------- ADDITION TESTS ----------
        [TestMethod]
        public void testAddition_SameUnit_KilogramPlusKilogram()
        {
            var w1 = new QuantityWeight(1.0, WeightUnit.Kilogram);
            var w2 = new QuantityWeight(2.0, WeightUnit.Kilogram);
            var sum = w1.Add(w2);
            Assert.AreEqual(3.0, sum.Value, Epsilon);
            Assert.AreEqual(WeightUnit.Kilogram, sum.Unit);
        }

        [TestMethod]
        public void testAddition_CrossUnit_KilogramPlusGram()
        {
            var w1 = new QuantityWeight(1.0, WeightUnit.Kilogram);
            var w2 = new QuantityWeight(1000.0, WeightUnit.Gram);
            var sum = w1.Add(w2);
            Assert.AreEqual(2.0, sum.Value, Epsilon);
        }

        [TestMethod]
        public void testAddition_CrossUnit_PoundPlusKilogram()
        {
            var w1 = new QuantityWeight(2.20462, WeightUnit.Pound);
            var w2 = new QuantityWeight(1.0, WeightUnit.Kilogram);
            var sum = w1.Add(w2);
            Assert.AreEqual(4.40924, sum.Value, 1e-5);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit()
        {
            var w1 = new QuantityWeight(1.0, WeightUnit.Kilogram);
            var w2 = new QuantityWeight(1000.0, WeightUnit.Gram);
            var sum = w1.Add(w2, WeightUnit.Gram);
            Assert.AreEqual(2000.0, sum.Value, Epsilon);
            Assert.AreEqual(WeightUnit.Gram, sum.Unit);
        }

        [TestMethod]
        public void testAddition_WithZero()
        {
            var w1 = new QuantityWeight(5.0, WeightUnit.Kilogram);
            var w2 = new QuantityWeight(0.0, WeightUnit.Gram);
            var sum = w1.Add(w2);
            Assert.AreEqual(5.0, sum.Value, Epsilon);
        }

        [TestMethod]
        public void testAddition_NegativeValues()
        {
            var w1 = new QuantityWeight(5.0, WeightUnit.Kilogram);
            var w2 = new QuantityWeight(-2000.0, WeightUnit.Gram);
            var sum = w1.Add(w2);
            Assert.AreEqual(3.0, sum.Value, Epsilon);
        }

        [TestMethod]
        public void testAddition_LargeValues()
        {
            var w1 = new QuantityWeight(1e6, WeightUnit.Kilogram);
            var w2 = new QuantityWeight(1e6, WeightUnit.Kilogram);
            var sum = w1.Add(w2);
            Assert.AreEqual(2e6, sum.Value, Epsilon);
        }
    }
}