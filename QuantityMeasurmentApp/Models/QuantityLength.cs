namespace QuantityMeasurmentApp.Models
{
    public class QuantityLength
    {
        private readonly double value;
        private readonly LengthUnit unit;

        public QuantityLength(double value, LengthUnit unit)
        {
            this.value = value;
            this.unit = unit;
        }

        private double ToFeet()
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
                    return (value * 0.393701) / 12.0;

                default:
                    throw new ArgumentException("Invalid Unit");
            }
        }

        public override bool Equals(object? obj)
        {
            if (this == obj)
                return true;

            if (obj == null || GetType() != obj.GetType())
                return false;

            QuantityLength other = (QuantityLength)obj;

            return Math.Abs(this.ToFeet() - other.ToFeet()) < 0.0001;
        }

        public override int GetHashCode()
        {
            return ToFeet().GetHashCode();
        }
    }
}