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
                    if (manager.findSerial(serial))
                    {
                        Console.Write("\nMeter model: ");
                        int model = int.Parse(Console.ReadLine());
                        Console.Write("\nMeter number: ");
                        int number = int.Parse(Console.ReadLine());
                        Console.Write("\nMeter firmware version: ");
                        string firmware = Console.ReadLine();
                        Console.Write("\nSwitch state: ");
                        int state = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        manager.addEndpoint(model, state, number, firmware, serial);
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadLine();
                    }
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Edit endpoint\n");
                    Console.Write("Endpoint serial number: ");
                    serial = Console.ReadLine();
                    Console.WriteLine();
                    if (manager.verifySerial(serial))
                    {
                        manager.findEndpoint(serial);
                        Console.WriteLine();
                        Console.Write("New endpoint switch state: ");
                        int state = int.Parse(Console.ReadLine());
                        manager.editEndpoint(serial, state);
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadLine();
                    }
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Delete endpoint\n");
                    Console.Write("Endpoint serial number: ");
                    serial = Console.ReadLine();
                    if (manager.verifySerial(serial))
                    {
                        manager.deleteEndpoint(serial);
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadLine();
                    }
                    break;
                case 4:
                    Console.Clear();
                    manager.listEndpoints();
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadLine();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Find endpoint\n");
                    Console.Write("Endpoint serial Number: ");
                    serial = Console.ReadLine();
                    Console.WriteLine();
                    if (manager.verifySerial(serial))
                    {
                        manager.findEndpoint(serial);
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadLine();
                    }
                    Console.Clear();
                    break;
                case 6:
                    Console.Clear();
                    manager.close();
                    break;
                default:
                    Console.WriteLine("\nNot a valid input");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadLine();
                    break;
            }
        }


    }
}
