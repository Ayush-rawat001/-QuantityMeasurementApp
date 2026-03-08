using System;
using QuantityMeasurmentApp.Models;

namespace QuantityMeasurmentApp.Services
{
    // Generic measurement service for all types of quantities
    public class MeasurementService
    {
        // Check equality of two quantities
        public bool AreEqual<U>(Quantity<U> q1, Quantity<U> q2) where U : struct
        {
            if (q1 == null || q2 == null)
                return false;

            return q1.Equals(q2);
        }

        // Add two quantities (result in first quantity's unit)
        public Quantity<U> Add<U>(Quantity<U> q1, Quantity<U> q2) where U : struct
        {
            if (q1 == null || q2 == null)
                throw new ArgumentException("Quantity cannot be null");

            return q1.Add(q2);
        }

        // Add two quantities and return result in a target unit
        public Quantity<U> Add<U>(Quantity<U> q1, Quantity<U> q2, U targetUnit) where U : struct
        {
            if (q1 == null || q2 == null)
                throw new ArgumentException("Quantity cannot be null");

            return q1.Add(q2, targetUnit);
        }

        // Convert a quantity to a target unit
        public Quantity<U> Convert<U>(Quantity<U> quantity, U targetUnit) where U : struct
        {
            if (quantity == null)
                throw new ArgumentException("Quantity cannot be null");

            return quantity.ConvertTo(targetUnit);
        }
    }
}