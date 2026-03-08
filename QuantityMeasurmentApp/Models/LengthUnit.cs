using System;

namespace QuantityMeasurmentApp.Models
{
    public enum LengthUnit
    {
        Feet,
        Inches,
        Yards,
        Centimeters
    }

    public static class LengthUnitExtensions
    {
        // Conversion factor to feet
        public static double GetConversionFactor(this LengthUnit unit)
        {
            switch (unit)
            {
                case LengthUnit.Feet:
                    return 1.0;

                case LengthUnit.Inches:
                    return 1.0 / 12.0;

                case LengthUnit.Yards:
                    return 3.0;

                case LengthUnit.Centimeters:
                    return 1.0 / 30.48;

                default:
                    throw new ArgumentException("Invalid unit");
            }
        }

        // Convert any unit → base unit (feet)
        public static double ConvertToBaseUnit(this LengthUnit unit, double value)
        {
            return value * unit.GetConversionFactor();
        }

        // Convert from base unit (feet) → target unit
        public static double ConvertFromBaseUnit(this LengthUnit unit, double valueInFeet)
        {
            return valueInFeet / unit.GetConversionFactor();
        }
    }
}