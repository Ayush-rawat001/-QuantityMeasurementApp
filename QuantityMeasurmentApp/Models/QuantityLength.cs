using System;

namespace QuantityMeasurmentApp.Models
{
    public class QuantityLength
    {
        private readonly double value;
        private readonly LengthUnit unit;

         public QuantityLength(double value, LengthUnit unit)
{
    if (double.IsNaN(value) || double.IsInfinity(value))
    {
        throw new ArgumentException("Invalid length value");
    }

    this.value = value;
    this.unit = unit;
}

        public double Value => value;
        public LengthUnit Unit => unit;

        // UC6
        public QuantityLength Add(QuantityLength other)
        {
            if (other == null)
                throw new ArgumentException("Second operand cannot be null");

            double firstFeet = LengthUnitConverter.ToFeet(Value, Unit);
            double secondFeet = LengthUnitConverter.ToFeet(other.Value, other.Unit);

            double sumFeet = firstFeet + secondFeet;

            double result = LengthUnitConverter.FromFeet(sumFeet, Unit);

            return new QuantityLength(result, Unit);
        }

        // UC7
        public QuantityLength Add(QuantityLength other, LengthUnit targetUnit)
        {
            if (other == null)
                throw new ArgumentException("Second operand cannot be null");

            double firstFeet = LengthUnitConverter.ToFeet(Value, Unit);
            double secondFeet = LengthUnitConverter.ToFeet(other.Value, other.Unit);

            double sumFeet = firstFeet + secondFeet;

            double result = LengthUnitConverter.FromFeet(sumFeet, targetUnit);

            return new QuantityLength(result, targetUnit);
        }

        // UC5
        public static double Convert(double value, LengthUnit source, LengthUnit target)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Invalid numeric value");

            double valueInFeet = LengthUnitConverter.ToFeet(value, source);

            return LengthUnitConverter.FromFeet(valueInFeet, target);
        }

        public QuantityLength ConvertTo(LengthUnit targetUnit)
        {
            double convertedValue = Convert(this.value, this.unit, targetUnit);
            return new QuantityLength(convertedValue, targetUnit);
        }

        public override bool Equals(object? obj)
        {
            if (this == obj)
                return true;

            if (obj == null || GetType() != obj.GetType())
                return false;

            QuantityLength other = (QuantityLength)obj;

            double thisFeet = LengthUnitConverter.ToFeet(this.value, this.unit);
            double otherFeet = LengthUnitConverter.ToFeet(other.value, other.unit);

            return Math.Abs(thisFeet - otherFeet) < 0.0001;
        }

        public override int GetHashCode()
        {
            double feet = LengthUnitConverter.ToFeet(value, unit);
            return feet.GetHashCode();
        }

        public override string ToString()
        {
            return $"{value} {unit}";
        }
    }
}