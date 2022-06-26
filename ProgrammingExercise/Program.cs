using ProgrammingExercise.Entities;

namespace ProgrammingExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            EndpointManager manager = new EndpointManager();

            while (!manager.exit)
            {
                try
                {
                    Console.Clear();
                    Screen.printTitle();
                    Screen.printMenu();
                    Console.Write("Input: ");
                    int input = int.Parse(Console.ReadLine());
                    Screen.choice(input, manager);

                }
                catch (EndpointException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Input must be a number");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadLine();
                }
            }
        }
        

    }
}