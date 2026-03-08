using System;
using QuantityMeasurmentApp.Models;

namespace QuantityMeasurmentApp.UI
{
    public class Menu
    {
        public void Start()
        {
            bool loop = true;

            while (loop)
            {
                Console.WriteLine("===== Welcome to Quantity Measurement App =====");
                Console.WriteLine("1) Compare Length");
                Console.WriteLine("2) Compare Weight");
                Console.WriteLine("3) Convert Length");
                Console.WriteLine("4) Convert Weight");
                Console.WriteLine("5) Add Length");
                Console.WriteLine("6) Add Weight");
                Console.WriteLine("7) Exit");

                int option;
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        CompareQuantity<LengthUnit>();
                        break;

                    case 2:
                        CompareQuantity<WeightUnit>();
                        break;

                    case 3:
                        ConvertQuantity<LengthUnit>();
                        break;

                    case 4:
                        ConvertQuantity<WeightUnit>();
                        break;

                    case 5:
                        AddQuantity<LengthUnit>();
                        break;

                    case 6:
                        AddQuantity<WeightUnit>();
                        break;

                    case 7:
                        loop = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        // Generic method to compare two quantities
        private void CompareQuantity<U>() where U : struct
        {
            Console.Write("Enter first value: ");
            double v1 = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter first unit: ");
            U u1 = (U)Enum.Parse(typeof(U), Console.ReadLine() ?? "", true);

            Console.Write("Enter second value: ");
            double v2 = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter second unit: ");
            U u2 = (U)Enum.Parse(typeof(U), Console.ReadLine() ?? "", true);

            var q1 = new Quantity<U>(v1, u1);
            var q2 = new Quantity<U>(v2, u2);

            bool result = q1.Equals(q2);
            Console.WriteLine(result ? "Equal" : "Not Equal");
            Console.WriteLine("--------------------------\n");
        }

        // Generic method to convert quantity
        private void ConvertQuantity<U>() where U : struct
        {
            Console.Write("Enter value: ");
            double value = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter source unit: ");
            U source = (U)Enum.Parse(typeof(U), Console.ReadLine() ?? "", true);

            Console.Write("Enter target unit: ");
            U target = (U)Enum.Parse(typeof(U), Console.ReadLine() ?? "", true);

            var quantity = new Quantity<U>(value, source);
            var converted = quantity.ConvertTo(target);

            Console.WriteLine($"Result: {converted.Value} {converted.Unit}");
            Console.WriteLine("--------------------------\n");
        }

        // Generic method to add two quantities
        private void AddQuantity<U>() where U : struct
        {
            Console.Write("Enter first value: ");
            double v1 = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter first unit: ");
            U u1 = (U)Enum.Parse(typeof(U), Console.ReadLine() ?? "", true);

            Console.Write("Enter second value: ");
            double v2 = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter second unit: ");
            U u2 = (U)Enum.Parse(typeof(U), Console.ReadLine() ?? "", true);

            Console.Write("Enter target unit for result: ");
            U target = (U)Enum.Parse(typeof(U), Console.ReadLine() ?? "", true);

            var q1 = new Quantity<U>(v1, u1);
            var q2 = new Quantity<U>(v2, u2);

            var sum = q1.Add(q2, target);

            Console.WriteLine($"Result: {sum.Value} {sum.Unit}");
            Console.WriteLine("--------------------------\n");
        }
    }
}