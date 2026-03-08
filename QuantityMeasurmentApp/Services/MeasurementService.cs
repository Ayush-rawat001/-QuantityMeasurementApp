using QuantityMeasurmentApp.Models;

namespace QuantityMeasurmentApp.Services
{
    public class MeasurementService
    {
        // Feet comparison
        public bool AreEqual(Feet f1, Feet f2)
        {
            if (f1 == null || f2 == null)
                return false;

            return f1.Equals(f2);
        }

        // Inches comparison
        public bool AreEqual(Inches i1, Inches i2)
        {
            if (i1 == null || i2 == null)
                return false;

            return i1.Equals(i2);
        }
    }
}