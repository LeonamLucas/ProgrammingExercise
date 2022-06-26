using ProgrammingExercise;

namespace ProgrammingExerciseTests
{
    [TestClass]
    public class EndpointManagerTests
    {
        [TestMethod]
        public void addEndPoint_ValidParameters_NewEndpointInHashset() //Confirms if a new endpoint can be found in the HashSet
        {
            //Arrange
            EndpointManager manager = new EndpointManager();

            //Act
            manager.addEndpoint(17, 3, 1005, "unit", "a5");

            //Assert
            Assert.IsTrue(manager.verifySerial("a5"));
        }

        [TestMethod]
        public void addEndPoint_InvalidParameters_ThrowsException() //Confirms if an exception is thrown if the serial number already exists
        {
            //Arrange
            EndpointManager manager = new EndpointManager();

            //Act and Assert
            Assert.ThrowsException<EndpointException>(() => manager.addEndpoint(17, 3, 1005, "unit", "a2"));
        }

        [TestMethod]
        public void deleteEndpoint_ValidSerialNumber_HashsetSmaller() //Confirms if the HashSet is smaller after removing an endpoint
        {
            //Arrange
            EndpointManager manager = new EndpointManager();
            int oldsize = manager.countEndpoints();

            //Act
            manager.deleteEndpoint("a4");

            //Assert
            Assert.AreNotEqual(oldsize, manager.countEndpoints());
        }

        [TestMethod]
        public void deleteEndpoint_InvalidSerialNumber_HashsetSameSize() //Confirms if the HashSet is the same size after trying to remove an invalid endpoint
        {
            //Arrange
            EndpointManager manager = new EndpointManager();
            int oldsize = manager.countEndpoints();

            //Act
            manager.deleteEndpoint("a6");

            //Assert
            Assert.AreEqual(oldsize, manager.countEndpoints());
        }
    }
}