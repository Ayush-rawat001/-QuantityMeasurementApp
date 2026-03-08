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
                Console.WriteLine("2) Convert Length");
                Console.WriteLine("3) Add Length");
                Console.WriteLine("4) Compare Weight");
                Console.WriteLine("5) Convert Weight");
                Console.WriteLine("6) Add Weight");
                Console.WriteLine("7) Exit");

                int option = int.Parse(Console.ReadLine() ?? "");

                switch (option)
                {
                    case 1:

                        Console.Write("Enter first value: ");
                        double v1 = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter unit (Feet/Inches/Yards/Centimeters): ");
                        LengthUnit u1 = Enum.Parse<LengthUnit>(Console.ReadLine(), true);

                        Console.Write("Enter second value: ");
                        double v2 = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter unit (Feet/Inches/Yards/Centimeters): ");
                        LengthUnit u2 = Enum.Parse<LengthUnit>(Console.ReadLine(), true);

                        QuantityLength q1 = new QuantityLength(v1, u1);
                        QuantityLength q2 = new QuantityLength(v2, u2);

                        bool result = service.AreEqual(q1, q2);

                        Console.WriteLine("--------------------------");
                        Console.WriteLine(result ? "Equal" : "Not Equal");
                        Console.WriteLine("--------------------------\n");

                        break;

                    case 2:

                        Console.Write("Enter value: ");
                        double value = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Convert from (Feet/Inches/Yards/Centimeters): ");
                        LengthUnit source = Enum.Parse<LengthUnit>(Console.ReadLine(), true);

                        Console.Write("Convert to (Feet/Inches/Yards/Centimeters): ");
                        LengthUnit target = Enum.Parse<LengthUnit>(Console.ReadLine(), true);

                        double converted = QuantityLength.Convert(value, source, target);

                        Console.WriteLine("--------------------------");
                        Console.WriteLine($"{value} {source} = {converted} {target}");
                        Console.WriteLine("--------------------------\n");

                        break;

                    case 3:

                        Console.Write("Enter first value: ");
                        double a = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter unit (Feet/Inches/Yards/Centimeters): ");
                        LengthUnit ua = Enum.Parse<LengthUnit>(Console.ReadLine(), true);

                        Console.Write("Enter second value: ");
                        double b = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter unit (Feet/Inches/Yards/Centimeters): ");
                        LengthUnit ub = Enum.Parse<LengthUnit>(Console.ReadLine(), true);

                        Console.Write("Enter target unit (Feet/Inches/Yards/Centimeters): ");
                        LengthUnit targetUnit = Enum.Parse<LengthUnit>(Console.ReadLine(), true);

                        QuantityLength l1 = new QuantityLength(a, ua);
                        QuantityLength l2 = new QuantityLength(b, ub);

                        QuantityLength sum = service.AddLengths(l1, l2, targetUnit);

                        Console.WriteLine("--------------------------");
                        Console.WriteLine($"Result: {sum.Value} {sum.Unit}");
                        Console.WriteLine("--------------------------\n");

                        break;

                    case 4:

                        Console.Write("Enter first weight: ");
                        double w1 = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter unit (Kilogram/Gram/Pound): ");
                        WeightUnit wu1 = Enum.Parse<WeightUnit>(Console.ReadLine(), true);

                        Console.Write("Enter second weight: ");
                        double w2 = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter unit (Kilogram/Gram/Pound): ");
                        WeightUnit wu2 = Enum.Parse<WeightUnit>(Console.ReadLine(), true);

                        QuantityWeight qw1 = new QuantityWeight(w1, wu1);
                        QuantityWeight qw2 = new QuantityWeight(w2, wu2);

                        bool weightResult = service.AreEqual(qw1, qw2);

                        Console.WriteLine("--------------------------");
                        Console.WriteLine(weightResult ? "Equal" : "Not Equal");
                        Console.WriteLine("--------------------------\n");

                        break;
                    case 6:

                        Console.Write("Enter first weight: ");
                        double wa = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter unit (Kilogram/Gram/Pound): ");
                        WeightUnit wua = Enum.Parse<WeightUnit>(Console.ReadLine(), true);

                        Console.Write("Enter second weight: ");
                        double wb = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter unit (Kilogram/Gram/Pound): ");
                        WeightUnit wub = Enum.Parse<WeightUnit>(Console.ReadLine(), true);

                        Console.Write("Enter target unit (Kilogram/Gram/Pound): ");
                        WeightUnit wtarget = Enum.Parse<WeightUnit>(Console.ReadLine(), true);

                        QuantityWeight qwA = new QuantityWeight(wa, wua);
                        QuantityWeight qwB = new QuantityWeight(wb, wub);

                        QuantityWeight weightSum = service.AddWeights(qwA, qwB, wtarget);

                        Console.WriteLine("--------------------------");
                        Console.WriteLine($"Result: {weightSum.Value} {weightSum.Unit}");
                        Console.WriteLine("--------------------------\n");

                        break;
                    case 7:
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