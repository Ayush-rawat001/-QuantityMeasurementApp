using QuantityMeasurmentApp.Models;

namespace QuantityMeasurmentApp.Services
{
    // Service class to perform measurement operations
    public class MeasurementService
    {
        // Method to check if two Feet objects are equal
        public bool AreEqual(Feet f1, Feet f2)
        {
            // If any object is null, they cannot be equal
            if (f1 == null || f2 == null)
                return false;

            // Call Equals method of Feet class to compare values
            return f1.Equals(f2);
        }

        

    }
}