namespace ProgrammingExercise
{
    interface IMeter
    {
        public Model modelId { get; }
        public int meterNumber { get; }
        public string firmwareVersion { get; }
    } 
}
