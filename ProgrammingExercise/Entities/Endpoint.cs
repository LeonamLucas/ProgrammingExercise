namespace ProgrammingExercise
{
    public class Endpoint : IMeter
    {
        public Model modelId { get; private set; }
        public State switchState { get; private set; }
        public int meterNumber { get; private set; }
        public string firmwareVersion { get; private set; }

        public string endPointSerialNumber { get; private set; }


        public Endpoint(Model modelId, State switchState, int meterNumber, string firmwareVersion, string endPointSerialNumber)
        {
            this.modelId = modelId;
            this.switchState = switchState;
            this.meterNumber = meterNumber;
            this.firmwareVersion = firmwareVersion;
            this.endPointSerialNumber = endPointSerialNumber;
        }
        public void changeState(int newState)
        {
            switchState = (State)newState;
        }
        public override string ToString()
        {
            return String.Format("Endpoint serial number: {0}\n" +
                "Meter model: {1}\n" +
                "Meter number: {2}\n" +
                "Meter firmware version: {3}\n" +
                "Switch state: {4}",
                endPointSerialNumber, modelId, meterNumber, firmwareVersion, switchState);
        }
    }
}
