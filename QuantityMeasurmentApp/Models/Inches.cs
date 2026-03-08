namespace QuantityMeasurmentApp.Models
{
    // Class to represent Inches measurement
    public class Inches
    {
        // Stores value in inches
        private readonly double value;

        // Constructor
        public Inches(double value)
        {
            this.value = value;
        }

        // Compare two Inches objects
        public override bool Equals(object obj)
        {
            // Same reference
            if (this == obj)
                return true;

            // Null or different type
            if (obj == null || GetType() != obj.GetType())
                return false;

            // Convert object
            Inches other = (Inches)obj;

            // Compare values
            return value.Equals(other.value);
        }

        // HashCode
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }
}