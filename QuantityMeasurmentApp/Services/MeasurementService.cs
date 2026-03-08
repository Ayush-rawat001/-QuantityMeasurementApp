using QuantityMeasurmentApp.Models;

namespace QuantityMeasurmentApp.Services
{
    public class MeasurementService
    {
        public bool AreEqual(QuantityLength q1, QuantityLength q2)
        {
            if (q1 == null || q2 == null)
                return false;

            return q1.Equals(q2);
        }
         public QuantityLength AddLengths(QuantityLength q1, QuantityLength q2)
        {
            if (q1 == null || q2 == null)
                throw new ArgumentException("Length cannot be null");

            return q1.Add(q2);
        }
    }
}