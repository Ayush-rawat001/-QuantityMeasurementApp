using System;

namespace QuantityMeasurmentApp.Models
{
    // Enum for weight units
    public enum WeightUnit
    {
        Kilogram,
        Gram,
        Pound
    }

    public static class WeightUnitExtensions
    {
        // Get conversion factor relative to base unit (Kilogram)
        public static double GetConversionFactor(this WeightUnit unit)
        {
            switch (unit)
            {
                case WeightUnit.Kilogram:
                    return 1.0;

                case WeightUnit.Gram:
                    return 0.001;       // 1 gram = 0.001 kilogram

                case WeightUnit.Pound:
                    return 0.453592;    // 1 pound ≈ 0.453592 kilogram

                default:
                    throw new ArgumentException("Invalid weight unit");
            }
        }

        // Convert value from this unit → base unit (Kilogram)
        public static double ConvertToBaseUnit(this WeightUnit unit, double value)
        {
            return value * unit.GetConversionFactor();
        }

        // Convert value from base unit (Kilogram) → this unit
        public static double ConvertFromBaseUnit(this WeightUnit unit, double valueInKg)
        {
            return valueInKg / unit.GetConversionFactor();
        }

        // Return unit name as string
        public static string GetUnitName(this WeightUnit unit)
        {
            return unit.ToString();
        }
    }
}