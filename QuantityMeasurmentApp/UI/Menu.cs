using QuantityMeasurmentApp.Services;
using QuantityMeasurmentApp.Models;

namespace QuantityMeasurementApp.UI
{
    class Menu
    {
        public void Start()
        {
            MeasurementService service = new MeasurementService();
            bool loop = true;

            while (loop)
            {
                Console.WriteLine("=====Welcome to Quantity Measurement App=====");
                Console.WriteLine("1) Compare Length");
                Console.WriteLine("2) Exit");

                int option = int.Parse(Console.ReadLine() ?? "");

                switch (option)
                {
                    case 1:

                        Console.Write("Enter first value: ");
                        double v1 = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter unit (Feet/Inches): ");
                        LengthUnit u1 = Enum.Parse<LengthUnit>(Console.ReadLine(), true);

                        Console.Write("Enter second value: ");
                        double v2 = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter unit (Feet/Inches): ");
                        LengthUnit u2 = Enum.Parse<LengthUnit>(Console.ReadLine(), true);

                        QuantityLength q1 = new QuantityLength(v1, u1);
                        QuantityLength q2 = new QuantityLength(v2, u2);

                        bool result = service.AreEqual(q1, q2);

                        Console.WriteLine("--------------------------");
                        Console.WriteLine(result ? "Equal" : "Not Equal");
                        Console.WriteLine("--------------------------\n");

                        break;

                    case 2:
                        loop = false;
                        break;

                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
        }
    }
}