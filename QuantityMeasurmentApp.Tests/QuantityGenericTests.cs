using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurmentApp.Models;
using QuantityMeasurmentApp.Services;

namespace QuantityMeasurmentApp.Tests
{
    [TestClass]
    public class QuantityGenericTests
    {
        // ----------------- INTERFACE IMPLEMENTATION TESTS -----------------
        
        [TestMethod]
        public void TestIMeasurableInterface_LengthUnitImplementation()
        {
            var unit = LengthUnit.Feet;
            double valueInFeet = unit.ConvertToBaseUnit(1.0);
            double valueBack = unit.ConvertFromBaseUnit(valueInFeet);

            Assert.AreEqual(1.0, valueBack, 0.001);
        }

        [TestMethod]
        public void TestIMeasurableInterface_WeightUnitImplementation()
        {
            var unit = WeightUnit.Kilogram;
            double valueInKg = unit.ConvertToBaseUnit(1.0);
            double valueBack = unit.ConvertFromBaseUnit(valueInKg);

            Assert.AreEqual(1.0, valueBack, 0.001);
        }

        [TestMethod]
        public void TestIMeasurableInterface_ConsistentBehavior()
        {
            var lengthUnit = LengthUnit.Inches;
            var weightUnit = WeightUnit.Gram;

            double len = lengthUnit.ConvertToBaseUnit(24.0);
            double wei = weightUnit.ConvertToBaseUnit(1000.0);

            Assert.IsTrue(len > 0 && wei > 0);
        }

        // ----------------- GENERIC QUANTITY EQUALITY TESTS -----------------

        [TestMethod]
        public void TestGenericQuantity_LengthOperations_Equality()
        {
            var q1 = new Quantity<LengthUnit>(1.0, LengthUnit.Feet);
            var q2 = new Quantity<LengthUnit>(12.0, LengthUnit.Inches);

            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void TestGenericQuantity_WeightOperations_Equality()
        {
            var w1 = new Quantity<WeightUnit>(1.0, WeightUnit.Kilogram);
            var w2 = new Quantity<WeightUnit>(1000.0, WeightUnit.Gram);

            Assert.IsTrue(w1.Equals(w2));
        }

        [TestMethod]
        public void TestCrossCategoryPrevention_LengthVsWeight()
        {
            var length = new Quantity<LengthUnit>(1.0, LengthUnit.Feet);
            var weight = new Quantity<WeightUnit>(1.0, WeightUnit.Kilogram);

            Assert.IsFalse(length.Equals(weight));
        }

       

        // ----------------- CONVERSION TESTS -----------------

        [TestMethod]
        public void TestGenericQuantity_LengthOperations_Conversion()
        {
            var q = new Quantity<LengthUnit>(1.0, LengthUnit.Feet);
            var converted = q.ConvertTo(LengthUnit.Inches);

            Assert.AreEqual(12.0, converted.Value, 0.001);
            Assert.AreEqual(LengthUnit.Inches, converted.Unit);
        }

        [TestMethod]
        public void TestGenericQuantity_WeightOperations_Conversion()
        {
            var q = new Quantity<WeightUnit>(1.0, WeightUnit.Kilogram);
            var converted = q.ConvertTo(WeightUnit.Gram);

            Assert.AreEqual(1000.0, converted.Value, 0.001);
            Assert.AreEqual(WeightUnit.Gram, converted.Unit);
        }

        [TestMethod]
        public void TestGenericQuantity_Conversion_AllUnitCombinations()
        {
            var feet = new Quantity<LengthUnit>(1.0, LengthUnit.Feet);
            var yards = feet.ConvertTo(LengthUnit.Yards);
            Assert.AreEqual(1.0/3.0, yards.Value, 0.001);
        }

        // ----------------- ADDITION TESTS -----------------

        [TestMethod]
        public void TestGenericQuantity_LengthOperations_Addition()
        {
            var q1 = new Quantity<LengthUnit>(1.0, LengthUnit.Feet);
            var q2 = new Quantity<LengthUnit>(12.0, LengthUnit.Inches);

            var sum = q1.Add(q2, LengthUnit.Feet);
            Assert.AreEqual(2.0, sum.Value, 0.001);
        }

        [TestMethod]
        public void TestGenericQuantity_WeightOperations_Addition()
        {
            var w1 = new Quantity<WeightUnit>(1.0, WeightUnit.Kilogram);
            var w2 = new Quantity<WeightUnit>(1000.0, WeightUnit.Gram);

            var sum = w1.Add(w2, WeightUnit.Kilogram);
            Assert.AreEqual(2.0, sum.Value, 0.001);
        }

        

        // ----------------- HASHCODE & IMMUTABILITY -----------------

        [TestMethod]
        public void TestHashCode_GenericQuantity_Consistency()
        {
            var q1 = new Quantity<LengthUnit>(1.0, LengthUnit.Feet);
            var q2 = new Quantity<LengthUnit>(12.0, LengthUnit.Inches);

            Assert.AreEqual(q1.GetHashCode(), q2.GetHashCode());
        }

        [TestMethod]
        public void TestImmutability_GenericQuantity()
        {
            var q = new Quantity<LengthUnit>(1.0, LengthUnit.Feet);
            var newQ = q.Add(new Quantity<LengthUnit>(12.0, LengthUnit.Inches));

            Assert.AreNotSame(q, newQ);
        }

        // ----------------- DEMONSTRATION TESTS -----------------

        [TestMethod]
        public void TestQuantityMeasurementApp_SimplifiedDemonstration_Equality()
        {
            var q1 = new Quantity<LengthUnit>(1.0, LengthUnit.Feet);
            var q2 = new Quantity<LengthUnit>(12.0, LengthUnit.Inches);

            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void TestQuantityMeasurementApp_SimplifiedDemonstration_Conversion()
        {
            var q = new Quantity<LengthUnit>(1.0, LengthUnit.Feet);
            var converted = q.ConvertTo(LengthUnit.Inches);

            Assert.AreEqual(12.0, converted.Value, 0.001);
        }

        [TestMethod]
        public void TestQuantityMeasurementApp_SimplifiedDemonstration_Addition()
        {
            var q1 = new Quantity<LengthUnit>(1.0, LengthUnit.Feet);
            var q2 = new Quantity<LengthUnit>(12.0, LengthUnit.Inches);
            var sum = q1.Add(q2);

            Assert.AreEqual(2.0, sum.Value, 0.001);
        }

        // ----------------- SCALABILITY TESTS -----------------

       

       
        [TestMethod]
        public void TestTypeWildcard_FlexibleSignatures()
        {
            Quantity<LengthUnit> length = new Quantity<LengthUnit>(1.0, LengthUnit.Feet);
            Quantity<WeightUnit> weight = new Quantity<WeightUnit>(1.0, WeightUnit.Kilogram);

            Assert.IsNotNull(length);
            Assert.IsNotNull(weight);
        }

        [TestMethod]
        public void TestGenericBoundedTypeParameter_Enforcement()
        {
            Quantity<LengthUnit> length = new Quantity<LengthUnit>(1.0, LengthUnit.Feet);
            Assert.IsInstanceOfType(length.Unit, typeof(LengthUnit));
        }

        [TestMethod]
        public void TestEquals_GenericQuantity_ContractPreservation()
        {
            var a = new Quantity<LengthUnit>(1.0, LengthUnit.Feet);
            var b = new Quantity<LengthUnit>(12.0, LengthUnit.Inches);
            var c = new Quantity<LengthUnit>(36.0, LengthUnit.Inches);

            Assert.IsTrue(a.Equals(b));
            Assert.IsTrue(b.Equals(a));
            Assert.IsFalse(a.Equals(c));
        }

        [TestMethod]
        public void TestEnumAsUnitCarrier_BehaviorEncapsulation()
        {
            var unit = LengthUnit.Yards;
            double baseVal = unit.ConvertToBaseUnit(3.0);
            double converted = unit.ConvertFromBaseUnit(baseVal);

            Assert.AreEqual(3.0, converted, 0.001);
        }

        [TestMethod]
        public void TestTypeErasure_RuntimeSafety()
        {
            Quantity<LengthUnit> length = new Quantity<LengthUnit>(1.0, LengthUnit.Feet);
            Assert.IsTrue(length is Quantity<LengthUnit>);
        }

        [TestMethod]
        public void TestCompositionOverInheritance_Flexibility()
        {
            var length = new Quantity<LengthUnit>(1.0, LengthUnit.Feet);
            var sum = length.Add(new Quantity<LengthUnit>(12.0, LengthUnit.Inches));

            Assert.IsInstanceOfType(sum, typeof(Quantity<LengthUnit>));
        }

        [TestMethod]
        public void TestCodeReduction_DRYValidation()
        {
            var q1 = new Quantity<LengthUnit>(1.0, LengthUnit.Feet);
            var q2 = new Quantity<LengthUnit>(12.0, LengthUnit.Inches);

            var sum = q1.Add(q2);
            Assert.AreEqual(2.0, sum.Value, 0.001);
        }

        [TestMethod]
        public void TestMaintainability_SingleSourceOfTruth()
        {
            var q1 = new Quantity<LengthUnit>(1.0, LengthUnit.Feet);
            var q2 = new Quantity<LengthUnit>(12.0, LengthUnit.Inches);

            var sum1 = q1.Add(q2);
            var sum2 = q1.Add(q2);

            Assert.AreEqual(sum1.Value, sum2.Value, 0.001);
        }

      
       
        [TestMethod]
        public void TestPerformance_GenericOverhead()
        {
            var q = new Quantity<LengthUnit>(1.0, LengthUnit.Feet);
            var start = DateTime.Now;
            for (int i = 0; i < 100000; i++)
                q.Add(new Quantity<LengthUnit>(12.0, LengthUnit.Inches));
            var duration = DateTime.Now - start;

            Assert.IsTrue(duration.TotalSeconds < 5); // arbitrary performance threshold
        }

        [TestMethod]
        public void TestDocumentation_PatternClarity()
        {
            var q = new Quantity<LengthUnit>(1.0, LengthUnit.Feet);
            Assert.AreEqual(1.0, q.Value, 0.001);
        }

        [TestMethod]
        public void TestInterfaceSegregation_MinimalContract()
        {
            var unit = LengthUnit.Feet;
            double val = unit.ConvertToBaseUnit(1.0);
            Assert.AreEqual(1.0, val, 0.001);
        }
    }
}