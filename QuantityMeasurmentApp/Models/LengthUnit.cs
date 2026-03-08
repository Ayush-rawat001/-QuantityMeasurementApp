using System;

namespace QuantityMeasurmentApp.Models
{
    // Enum for length units implementing IMeasurable
    public enum LengthUnit
    {
        Feet,
        Inches,
        Yards,
        Centimeters
    }

    public static class LengthUnitExtensions
    {
        // Get conversion factor relative to base unit (Feet)
        public static double GetConversionFactor(this LengthUnit unit)
        {
            switch (unit)
            {
                case LengthUnit.Feet:
                    return 1.0;

                case LengthUnit.Inches:
                    return 1.0 / 12.0;  // 1 inch = 1/12 feet

                case LengthUnit.Yards:
                    return 3.0;          // 1 yard = 3 feet

                case LengthUnit.Centimeters:
                    return 1.0 / 30.48;  // 1 cm = 1/30.48 feet

                default:
                    throw new ArgumentException("Invalid length unit");
            }
        }

        // Convert value from this unit → base unit (Feet)
        public static double ConvertToBaseUnit(this LengthUnit unit, double value)
        {
            return value * unit.GetConversionFactor();
        }

        // Convert value from base unit (Feet) → this unit
        public static double ConvertFromBaseUnit(this LengthUnit unit, double valueInFeet)
        {
            return valueInFeet / unit.GetConversionFactor();
        }

        // Return the unit name as string
        public static string GetUnitName(this LengthUnit unit)
        {
            return unit.ToString();
        }
    }
}