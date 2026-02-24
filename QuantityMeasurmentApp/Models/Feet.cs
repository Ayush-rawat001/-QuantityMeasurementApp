namespace QuantityMeasurmentApp.Models
{
    // Class to represent Feet measurement
    public class Feet
    {
        // Stores the value in feet
        private readonly double value;

        // Constructor to set value
        public Feet(double value)
        {
            this.value = value;
        }

        // Method to compare two Feet objects
        public override bool Equals(object obj)
        {
            // If both references are same object
            if (this == obj)
                return true;

            // If object is null or not Feet type
            if (obj == null || GetType() != obj.GetType())
                return false;

            // Convert object to Feet type
            Feet other = (Feet)obj;

            // Compare values
            return value.Equals(other.value);
        }

        // Returns hash code of value
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }
}