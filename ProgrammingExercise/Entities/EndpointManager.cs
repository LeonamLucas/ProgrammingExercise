using ProgrammingExercise;

namespace ProgrammingExercise
{
    public class EndpointManager
    {
        public bool exit { get; private set; }
        private HashSet<Endpoint> endpoints;

        public EndpointManager()
        {
            exit = false;
            endpoints = new HashSet<Endpoint>();

            addEndpoint(19, 0, 1001, "beta_0.1", "a1");
            addEndpoint(18, 1, 1002, "beta_0.2", "a2");
            addEndpoint(17, 1, 1003, "final_2.0", "a3");
            addEndpoint(16, 2, 1004, "testing", "a4");
        }
        public void addEndpoint(int modelId, int switchState, int meterNumber, string firmwareVersion, string endPointSerialNumber) //Adds a new endpoint to the endpoints HashSet
        {
            findSerial(endPointSerialNumber);
            endpoints.Add(new Endpoint((Model)modelId, (State)switchState, meterNumber, firmwareVersion, endPointSerialNumber));
            Console.WriteLine(endpoints.Last());
        }
        public void editEndpoint(string endPointSerialNumber, int state)
        {
            var endpoint = endpoints.Where(e => e.endPointSerialNumber == endPointSerialNumber).SingleOrDefault(); //Finds the endpoint that matches the serial number

            Console.WriteLine();
            endpoint.changeState(state); //Changes the switch state to the new value
            Console.WriteLine(endpoint);
        }
        public void deleteEndpoint(string endPointSerialNumber)
        {
            var endpoint = endpoints.Where(e => e.endPointSerialNumber == endPointSerialNumber).SingleOrDefault(); //Finds the endpoint that matches the serial number

            endpoints.Remove(endpoint);
            Console.WriteLine("Endpoint deleted...");
        }
        public void listEndpoints() //Prints all endpoints
        {
            foreach (Endpoint endpoint in endpoints)
            {
                Console.WriteLine("\n=============================\n");
                Console.WriteLine(endpoint);
            }
        }
        public void findEndpoint(string endPointSerialNumber)
        {
            var endpoint =
                (from point in endpoints
                where point.endPointSerialNumber == endPointSerialNumber //Finds the endpoint that matches the serial number
                select point).SingleOrDefault();

            Console.WriteLine(endpoint); //Prints the endpoint
        }
        
        public bool verifySerial(string endPointSerialNumber) //Returns true if the serial number exists
        {
            if (endPointSerialNumber == "")
            {
                throw new EndpointException("Endpoint serial number can't be empty");
            }

            var endpoint = endpoints.Where(e => e.endPointSerialNumber == endPointSerialNumber).SingleOrDefault(); //Finds the endpoint that matches the serial number

            if (endpoint != null)
            {
                return true;
            }
            else
            {
                throw new EndpointException("Endpoint not found");
            }
        }
        public bool findSerial(string endPointSerialNumber) //Returns true if the serial number does not exist
        {
            if (endPointSerialNumber == "")
            {
                throw new EndpointException("Endpoint serial number can't be empty");
            }

            var endpoint = endpoints.Where(e => e.endPointSerialNumber == endPointSerialNumber).SingleOrDefault(); //Finds the endpoint that matches the serial number

            if (endpoint == null)
            {
                return true;
            }
            else
            {
                throw new EndpointException("Endpoint already exists");
            }
        }

        public int countEndpoints()
        {
            return endpoints.Count();
        }
        public void close() //Changes the exit flag if confirmed
        {
            Console.WriteLine("Are you sure you want to leave? (Y - N)\n");
            char confirm = char.Parse(Console.ReadLine().ToLower());

            if (confirm == 'y')
            {
                exit = true;
            }
            else if (confirm == 'n')
            {
                exit = false;
            }
            else
            {
                throw new EndpointException("Must be 'Y' or 'N'");
            }
        }
    }
}
