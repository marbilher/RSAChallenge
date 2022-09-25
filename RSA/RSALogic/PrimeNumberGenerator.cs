using System.Diagnostics;

namespace RSALogic
{
    public class PrimeNumberGenerator
    {
        public PrimeNumberGenerator()
        {
        }
        public bool isPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2 || number == 3 || number == 5) return true;
            if (number % 2 == 0 || number % 3 == 0 || number % 5 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));
            for (int i = 6; i <= boundary; i += 6) { 
                if (number % (i + 1) == 0 || number % (i + 5) == 0)
                {
                    return false;
                }
                i += 6;
            }
            return true;
        }

        //During dev we can use smaller numbers, for larger numbers we can use
        //https://stackoverflow.com/questions/25702173/c-sharp-sieve-of-eratosthenes
        public int GetNewPrime(int lowerLimit, int upperLimit)
        {
            List<int> primes = new List<int>();
            primes.Add(2);
            int nextPrime = 3;
            int lowerLimitIndex = -1;
            while (nextPrime < upperLimit)
            {
                int sqrt = (int)Math.Sqrt(nextPrime);
                bool isPrime = true;
                for (int i = 0; (int)primes[i] <= sqrt; i++)
                {
                    if (nextPrime % primes[i] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime && nextPrime > lowerLimit && lowerLimitIndex == -1)
                {
                    primes.Add(nextPrime);
                    lowerLimitIndex = primes.Count - 1;
                }
                else if (isPrime)
                {
                    Debug.WriteLine("Prime found: " + nextPrime);
                    primes.Add(nextPrime);
                }

                nextPrime += 2;
            }
            Random rnd = new Random();
            int randomIndex = rnd.Next(lowerLimitIndex, primes.Count - 1);
            return primes[randomIndex];
        }
    }
}

//easiest thing to do?
//we have a list of primes from 2 to upper limit
//we want a random value between lower and upper
//i will have list count... i can store index of first greater than lower limit