using ProgrammingExercise;

namespace ProgrammingExerciseTests
{
    [TestClass]
    public class EndpointManagerTests
    {
        [TestMethod]
        public void addEndPoint_ValidParameters_NewEndpointInHashset()
        {
            //Arrange
            EndpointManager manager = new EndpointManager();

            //Act
            manager.addEndpoint(17, 3, 1005, "unit", "a5");

            //Assert
            Assert.IsTrue(manager.verifySerial("a5"));
        }

        [TestMethod]
        public void verifySerial_InvalidParameters_HashsetSameSize()
        {
            //Arrange
            EndpointManager manager = new EndpointManager();

            //Act
            bool result = manager.verifySerial("a2");

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void deleteEndpoint_ValidSerialNumber_HashsetSmaller()
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
        public void deleteEndpoint_InvalidSerialNumber_HashsetSameSize()
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