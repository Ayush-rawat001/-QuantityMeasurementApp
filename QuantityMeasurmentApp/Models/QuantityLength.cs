using System;

namespace QuantityMeasurmentApp.Models
{
    public class QuantityLength
    {
        private readonly double value;
        private readonly LengthUnit unit;

        public QuantityLength(double value, LengthUnit unit)
        {
            this.value = value;
            this.unit = unit;
        }

        public double Value => value;
        public LengthUnit Unit => unit;



        //UC6 
        public QuantityLength Add(QuantityLength other)
        {
            if (other == null)
                throw new ArgumentException("Second operand cannot be null");

            // Convert both to base unit (feet)
            double firstInFeet = Convert(Value, Unit, LengthUnit.Feet);
            double secondInFeet = Convert(other.Value, other.Unit, LengthUnit.Feet);

            // Add
            double sumFeet = firstInFeet + secondInFeet;

            // Convert back to unit of first operand
            double result = Convert(sumFeet, LengthUnit.Feet, Unit);

            return new QuantityLength(result, Unit);
        }
        private double ToFeet()
        {
            switch (unit)
            {
                case LengthUnit.Feet:
                    return value;

                case LengthUnit.Inches:
                    return value / 12.0;

                case LengthUnit.Yards:
                    return value * 3.0;

                case LengthUnit.Centimeters:
                    return (value * 0.393701) / 12.0;

                default:
                    throw new ArgumentException("Invalid Unit");
            }
        }

        // Convert from any unit to feet
        private static double ToFeet(double value, LengthUnit unit)
        {
            switch (unit)
            {
                case LengthUnit.Feet:
                    return value;

                case LengthUnit.Inches:
                    return value / 12.0;

                case LengthUnit.Yards:
                    return value * 3.0;

                case LengthUnit.Centimeters:
                    return (value * 0.393701) / 12.0;

                default:
                    throw new ArgumentException("Invalid Unit");
            }
        }

        // Convert from feet to target unit
        private static double FromFeet(double valueInFeet, LengthUnit target)
        {
            switch (target)
            {
                case LengthUnit.Feet:
                    return valueInFeet;

                case LengthUnit.Inches:
                    return valueInFeet * 12.0;

                case LengthUnit.Yards:
                    return valueInFeet / 3.0;

                case LengthUnit.Centimeters:
                    return valueInFeet * 30.48;

                default:
                    throw new ArgumentException("Invalid Unit");
            }
        }

        // UC5 main API
        public static double Convert(double value, LengthUnit source, LengthUnit target)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Invalid numeric value");

            double valueInFeet = ToFeet(value, source);

            return FromFeet(valueInFeet, target);
        }

        // Instance conversion
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

            return Math.Abs(this.ToFeet() - other.ToFeet()) < 0.0001;
        }

        public override int GetHashCode()
        {
            return ToFeet().GetHashCode();
        }

        public override string ToString()
        {
            return $"{value} {unit}";
        }
    }
}