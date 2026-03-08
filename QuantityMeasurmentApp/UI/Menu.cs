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
                Console.WriteLine("1) Compare Feet");
                Console.WriteLine("2) Compare Inches");
                Console.WriteLine("3) Exit");

                int option = int.Parse(Console.ReadLine() ?? "");

                switch (option)
                {
                    case 1:

                        Console.Write("Enter first value in feet: ");
                        double v1 = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter second value in feet: ");
                        double v2 = Convert.ToDouble(Console.ReadLine());

                        Feet f1 = new Feet(v1);
                        Feet f2 = new Feet(v2);

                        bool resultFeet = service.AreEqual(f1, f2);

                        Console.WriteLine("--------------------------");
                        Console.Write("Values are ");
                        Console.WriteLine(resultFeet ? "Equal" : "Not Equal");
                        Console.WriteLine("--------------------------\n");
                        break;

                    case 2:

                        Console.Write("Enter first value in inches: ");
                        double i1 = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter second value in inches: ");
                        double i2 = Convert.ToDouble(Console.ReadLine());

                        Inches inch1 = new Inches(i1);
                        Inches inch2 = new Inches(i2);

                        bool resultInches = service.AreEqual(inch1, inch2);

                        Console.WriteLine("--------------------------");
                        Console.Write("Values are ");
                        Console.WriteLine(resultInches ? "Equal" : "Not Equal");
                        Console.WriteLine("--------------------------\n");
                        break;

                    case 3:
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