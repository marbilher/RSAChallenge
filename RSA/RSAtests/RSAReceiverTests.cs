using RSALogic;

namespace RSAtests

{
    
        //We can mock a message and expected response for receiver class tests
        [TestClass]
        public class ReceiverClassTests
        {
            [TestMethod]
            public void TestReceiver()
            {

                var primeNumberGen = new PrimeNumberGenerator();
                var receiver = new RSAReceiver(primeNumberGen);
            }
        }
    }