using QuantityMeasurmentApp.Services;
using QuantityMeasurmentApp.Models;

namespace QuantityMeasurementApp.UI
{
    // Menu class handles user interaction
    class Menu
    {
        // Method to start the menu loop
        public void Start()
        {
            // Create service object
            MeasurementService service = new MeasurementService();

            // Loop control variable
            bool loop = true;

            // Runs until user chooses Exit
            while (loop)
            {
                // Display menu
                Console.WriteLine("=====Welcome to Quantity Measurement App=====");
                Console.WriteLine("1) Compare Feet");
                
                Console.WriteLine("2) Exit");

                // Read user option
                int option = int.Parse(Console.ReadLine() ?? "");

                // Perform action based on user choice
                switch (option)
                {
                    
                    case 1:
                        // Take first input
                        Console.Write("Enter first value in feet: ");
                        double v1 = Convert.ToDouble(Console.ReadLine());

                        // Take second input
                        Console.Write("Enter second value in feet: ");
                        double v2 = Convert.ToDouble(Console.ReadLine());

                        // Create Feet objects
                        Feet f1 = new Feet(v1);
                        Feet f2 = new Feet(v2);

                        // Compare values using service
                        bool result = service.AreEqual(f1, f2);

                        // Display result
                        Console.WriteLine("--------------------------");
                        Console.Write("Values are ");
                        Console.WriteLine(result ? "Equal" : "Not Equal");
                        Console.WriteLine("--------------------------\n");
                        break;

                    

                    case 3:
                        // Exit loop
                        loop = false;
                        break;

                    default:
                        // Invalid input case
                        Console.WriteLine("invalid Input");
                        break;
                }
            }
        }
    }
}