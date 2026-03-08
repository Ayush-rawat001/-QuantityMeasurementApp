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

        // UC6
        public QuantityLength AddLengths(QuantityLength q1, QuantityLength q2)
        {
            if (q1 == null || q2 == null)
                throw new ArgumentException("Length cannot be null");

            return q1.Add(q2);
        }

        // UC7
        public QuantityLength AddLengths(QuantityLength q1, QuantityLength q2, LengthUnit targetUnit)
        {
            if (q1 == null || q2 == null)
                throw new ArgumentException("Length cannot be null");

            return q1.Add(q2, targetUnit);
        }

        // ---------- UC9 WEIGHT METHODS ----------

        public bool AreEqual(QuantityWeight q1, QuantityWeight q2)
        {
            if (q1 == null || q2 == null)
                return false;

            return q1.Equals(q2);
        }

        public QuantityWeight AddWeights(QuantityWeight q1, QuantityWeight q2)
        {
            if (q1 == null || q2 == null)
                throw new ArgumentException("Weight cannot be null");

            return q1.Add(q2);
        }

        public QuantityWeight AddWeights(QuantityWeight q1, QuantityWeight q2, WeightUnit targetUnit)
        {
            if (q1 == null || q2 == null)
                throw new ArgumentException("Weight cannot be null");

            return q1.Add(q2, targetUnit);
        }
    }
}