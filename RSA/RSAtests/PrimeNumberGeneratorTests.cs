using RSALogic;
using System;
using System.Diagnostics;

namespace RSAtests
{
    [TestClass]
    public class PrimeNumberGeneratorTests
    {
        [TestMethod]
        public void TestIsPrime()
        {
            var primeNumberGen = new PrimeNumberGenerator();
            var result = primeNumberGen.isPrime(13);
            Assert.IsTrue(result);
            result = primeNumberGen.isPrime(12);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestGetNewPrime()
        {
            var primeNumberGen = new PrimeNumberGenerator();
            int lowerLimit = 3;
            int upperLimit = 100;
            var result = primeNumberGen.GetNewPrime(3, 15);
            Debug.WriteLine("Random prime test result: " + result);
            Assert.IsTrue(primeNumberGen.isPrime(result));
            Assert.IsTrue(result > lowerLimit && result < upperLimit);
        }
    }
}
