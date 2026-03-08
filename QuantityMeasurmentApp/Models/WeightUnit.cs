using System;

namespace QuantityMeasurmentApp.Models
{
    public enum WeightUnit
    {
        Kilogram,
        Gram,
        Pound
    }

    public static class WeightUnitExtensions
    {
        // Conversion factor relative to kilogram (base unit)
        public static double GetConversionFactor(this WeightUnit unit)
        {
            switch (unit)
            {
                case WeightUnit.Kilogram:
                    return 1.0;

                case WeightUnit.Gram:
                    return 0.001;

                case WeightUnit.Pound:
                    return 0.453592;

                default:
                    throw new ArgumentException("Invalid weight unit");
            }
        }

        // Convert unit → kilograms
        public static double ConvertToBaseUnit(this WeightUnit unit, double value)
        {
            return value * unit.GetConversionFactor();
        }

        // Convert kilograms → target unit
        public static double ConvertFromBaseUnit(this WeightUnit unit, double valueInKg)
        {
            return valueInKg / unit.GetConversionFactor();
        }
    }
}