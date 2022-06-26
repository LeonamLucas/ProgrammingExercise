using ProgrammingExercise;

namespace ProgrammingExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            EndpointManager manager = new EndpointManager(); //Object used to manage and access endpoints

            while (!manager.exit)
            {
                try
                {
                    Console.Clear();
                    Screen.printTitle();
                    Screen.printMenu();
                    Console.Write("Input: ");
                    int input = int.Parse(Console.ReadLine());

                    Screen.choice(input, manager);  //Calls other functions

                }
                catch (EndpointException e)
                {
                    Console.WriteLine();
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
                catch (FormatException e)
                {
                    Console.WriteLine();
                    Console.WriteLine("Input must be a number");
                    Console.ReadLine();
                }
                
            }
        }
        

    }
}