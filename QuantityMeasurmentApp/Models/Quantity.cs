using System;

namespace QuantityMeasurmentApp.Models
{
    // Generic class for any measurable quantity
    public class Quantity<U> where U : struct
    {
        private readonly double value;
        private readonly U unit;

        public double Value => value;
        public U Unit => unit;

        // Constructor validates input
        public Quantity(double value, U unit)
{
    if (double.IsNaN(value) || double.IsInfinity(value))
        throw new ArgumentException("Invalid value");

    this.value = value;
    this.unit = unit; // no need to check for null
}

        // Convert to another unit
        public Quantity<U> ConvertTo(U targetUnit)
        {
            double baseValue = ToBaseUnit(value, unit);
            double convertedValue = FromBaseUnit(baseValue, targetUnit);
            return new Quantity<U>(convertedValue, targetUnit);
        }

        // Add another quantity (result in this quantity's unit)
        public Quantity<U> Add(Quantity<U> other)
        {
            if (other == null)
                throw new ArgumentException("Other quantity cannot be null");

            double sumBase = ToBaseUnit(value, unit) + ToBaseUnit(other.value, other.unit);
            double result = FromBaseUnit(sumBase, unit);
            return new Quantity<U>(result, unit);
        }

        // Add another quantity with explicit target unit
        public Quantity<U> Add(Quantity<U> other, U targetUnit)
        {
            if (other == null)
                throw new ArgumentException("Other quantity cannot be null");

            double sumBase = ToBaseUnit(value, unit) + ToBaseUnit(other.value, other.unit);
            double result = FromBaseUnit(sumBase, targetUnit);
            return new Quantity<U>(result, targetUnit);
        }

        // Equality check
        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;

            if (obj == null || GetType() != obj.GetType())
                return false;

            Quantity<U> other = (Quantity<U>)obj;

            double thisBase = ToBaseUnit(value, unit);
            double otherBase = ToBaseUnit(other.value, other.unit);

            return Math.Abs(thisBase - otherBase) < 0.0001;
        }

        public override int GetHashCode()
        {
            double baseValue = ToBaseUnit(value, unit);
            return baseValue.GetHashCode();
        }

        public override string ToString()
        {
            return $"{value} {unit}";
        }

        // Helper: convert quantity to base unit (feet, kg, etc.)
        private double ToBaseUnit(double val, U u)
        {
            if (u is LengthUnit lu)
                return LengthUnitExtensions.ConvertToBaseUnit(lu, val);

            if (u is WeightUnit wu)
                return WeightUnitExtensions.ConvertToBaseUnit(wu, val);

            throw new ArgumentException("Unsupported unit type");
        }

        // Helper: convert quantity from base unit to target unit
        private double FromBaseUnit(double baseVal, U u)
        {
            if (u is LengthUnit lu)
                return LengthUnitExtensions.ConvertFromBaseUnit(lu, baseVal);

            if (u is WeightUnit wu)
                return WeightUnitExtensions.ConvertFromBaseUnit(wu, baseVal);

            throw new ArgumentException("Unsupported unit type");
        }
    }
}