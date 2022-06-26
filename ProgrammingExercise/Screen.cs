using ProgrammingExercise;

namespace ProgrammingExercise
{
    internal class Screen
    {
        public static void printTitle()
        {
            Console.WriteLine("=============================");
            Console.WriteLine("     ENDPOINT MANAGEMENT     ");
            Console.WriteLine("=============================");
            Console.WriteLine("\n\n");
        }
        public static void printMenu()
        {
            Console.WriteLine("1 - Insert new endpoint");
            Console.WriteLine("2 - Edit existing endpoint");
            Console.WriteLine("3 - Delete existing endpoint");
            Console.WriteLine("4 - List all endpoints");
            Console.WriteLine("5 - Find endpoint by serial number");
            Console.WriteLine("6 - Exit\n");
        }
        public static void choice(int input, EndpointManager manager)
        {
            string serial;
            switch (input)
            {
                case 1:

                    Console.Clear();
                    Console.WriteLine("Insert new endpoint\n");
                    Console.Write("Endpoint serial Number: ");
                    serial = Console.ReadLine();

                    manager.findSerial(serial); //Returns true if the serial number does not exist

                    Console.Write("\nMeter model: ");
                    int model = int.Parse(Console.ReadLine());
                    Console.Write("\nMeter number: ");
                    int number = int.Parse(Console.ReadLine());
                    Console.Write("\nMeter firmware version: ");
                    string firmware = Console.ReadLine();
                    Console.Write("\nSwitch state: ");
                    int state = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    manager.addEndpoint(model, state, number, firmware, serial); //Adds a new endpoint to the endpoints HashSet

                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                case 2:

                    Console.Clear();
                    Console.WriteLine("Edit endpoint\n");
                    Console.Write("Endpoint serial number: ");
                    serial = Console.ReadLine();
                    Console.WriteLine();

                    manager.verifySerial(serial); //Returns true if the serial number exists
                    manager.findEndpoint(serial); //Prints the endpoint with the corresponding serial number

                    Console.WriteLine();
                    Console.Write("New endpoint switch state: ");

                    state = int.Parse(Console.ReadLine());
                    manager.editEndpoint(serial, state); //Changes the switch state to a new value

                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadLine();

                    break;
                case 3:

                    Console.Clear();
                    Console.WriteLine("Delete endpoint\n");
                    Console.Write("Endpoint serial number: ");
                    serial = Console.ReadLine();

                    manager.verifySerial(serial); //Returns true if the serial number exists
                    manager.deleteEndpoint(serial); //Removes the endpoint with the corresponding serial number from the HashSet

                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadLine();

                    break;
                case 4:

                    Console.Clear();

                    manager.listEndpoints(); //Prints all endpoints

                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadLine();

                    break;
                case 5:

                    Console.Clear();
                    Console.WriteLine("Find endpoint\n");
                    Console.Write("Endpoint serial Number: ");
                    serial = Console.ReadLine();
                    Console.WriteLine();

                    manager.verifySerial(serial); //Returns true if the serial number exists
                    manager.findEndpoint(serial); //Prints the endpoint with the corresponding serial number

                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadLine();
                    Console.Clear();

                    break;
                case 6:

                    Console.Clear();
                    manager.close(); // Changes the exit flag

                    break;
                default:

                    throw new EndpointException("Input out of the expected range");

                    break;
            }
        }


    }
}
