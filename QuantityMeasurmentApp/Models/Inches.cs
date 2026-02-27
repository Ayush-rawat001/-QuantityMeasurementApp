namespace QuantityMeasurmentApp.Models
{
    // Class to represent Inches measurement
    public class Inches
    {
        private readonly double value;

        // Constructor
        public Inches(double value)
        {
            this.value = value;
        }

        // Equality comparison
        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;

            if (obj == null || GetType() != obj.GetType())
                return false;

            Inches other = (Inches)obj;

            return value.Equals(other.value);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }
}