using System;

namespace QuantityMeasurmentApp.Models
{
    // Interface for all measurable units (length, weight, etc.)
    public interface IMeasurable
    {
        // Return the conversion factor relative to base unit
        double GetConversionFactor();

        // Convert a value in this unit to base unit
        double ConvertToBaseUnit(double value);

        // Convert a value from base unit to this unit
        double ConvertFromBaseUnit(double valueInBaseUnit);

        // Return unit name as string
        string GetUnitName();
    }
}