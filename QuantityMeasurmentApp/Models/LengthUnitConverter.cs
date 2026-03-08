using System;

namespace QuantityMeasurmentApp.Models
{
    public static class LengthUnitConverter
    {
        // Convert any unit to feet
        public static double ToFeet(double value, LengthUnit unit)
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
                    return value / 30.48;

                default:
                    throw new ArgumentException("Invalid Unit");
            }
        }

        // Convert feet to target unit
        public static double FromFeet(double feetValue, LengthUnit target)
        {
            switch (target)
            {
                case LengthUnit.Feet:
                    return feetValue;

                case LengthUnit.Inches:
                    return feetValue * 12.0;

                case LengthUnit.Yards:
                    return feetValue / 3.0;

                case LengthUnit.Centimeters:
                    return feetValue * 30.48;

                default:
                    throw new ArgumentException("Invalid Unit");
            }
        }
    }
}