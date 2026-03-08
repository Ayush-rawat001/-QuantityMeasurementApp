using System;

namespace QuantityMeasurmentApp.Models
{
    public class QuantityWeight
    {
        private readonly double value;
        private readonly WeightUnit unit;

        public double Value => value;
        public WeightUnit Unit => unit;

        public QuantityWeight(double value, WeightUnit unit)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Invalid weight value");

            this.value = value;
            this.unit = unit;
        }

        // Convert to another unit
        public QuantityWeight ConvertTo(WeightUnit targetUnit)
        {
            double baseKg = unit.ConvertToBaseUnit(value);

            double converted = targetUnit.ConvertFromBaseUnit(baseKg);

            return new QuantityWeight(converted, targetUnit);
        }

        // Add with default unit (first operand unit)
        public QuantityWeight Add(QuantityWeight other)
        {
            if (other == null)
                throw new ArgumentException("Second operand cannot be null");

            double firstKg = unit.ConvertToBaseUnit(value);
            double secondKg = other.unit.ConvertToBaseUnit(other.value);

            double sumKg = firstKg + secondKg;

            double result = unit.ConvertFromBaseUnit(sumKg);

            return new QuantityWeight(result, unit);
        }

        // Add with explicit target unit
        public QuantityWeight Add(QuantityWeight other, WeightUnit targetUnit)
        {
            if (other == null)
                throw new ArgumentException("Second operand cannot be null");

            double firstKg = unit.ConvertToBaseUnit(value);
            double secondKg = other.unit.ConvertToBaseUnit(other.value);

            double sumKg = firstKg + secondKg;

            double result = targetUnit.ConvertFromBaseUnit(sumKg);

            return new QuantityWeight(result, targetUnit);
        }

        public override bool Equals(object? obj)
        {
            if (this == obj)
                return true;

            if (obj == null || GetType() != obj.GetType())
                return false;

            QuantityWeight other = (QuantityWeight)obj;

            double thisKg = unit.ConvertToBaseUnit(value);
            double otherKg = other.unit.ConvertToBaseUnit(other.value);

            return Math.Abs(thisKg - otherKg) < 0.0001;
        }

        public override int GetHashCode()
        {
            double kg = unit.ConvertToBaseUnit(value);
            return kg.GetHashCode();
        }

        public override string ToString()
        {
            return $"{value} {unit}";
        }
    }
}