

using System.Numerics;
namespace RSALogic;

public class RSAReceiver
{
    //in actual use cases these will > 1024 bit integers
    //yeah, to send a longer message i'll need to use BigInteger: https://stackoverflow.com/questions/10061626/message-length-restriction-in-rsa
    private int _p;
    private int _q;
    private int _n; //public key, n = p * q
    private int _phiN; //phi(n) = (p-1) * (q-1)
    private int _e; //public key exponent, must be smaller than _phiN and coprime to _phiN
    private int _d; //private key
    private int _address; //address of the receiver
    PrimeNumberGenerator _primeNumberGen;
    public RSAReceiver(PrimeNumberGenerator primeNumberGen)
    {
        _primeNumberGen = primeNumberGen;
        SetUp();
    }
    
    private void SetUp()
    {
        GenerateN(_primeNumberGen);
        SelectE(_p, _q, _n);
        CalculateD( _phiN, _e);
        Random rnd = new Random();
        _address = rnd.Next(100000, 1800000);

    }

    //Constraining values for testing
    private void GenerateN(PrimeNumberGenerator primeNumberGen)
    {   
        _p = primeNumberGen.GetNewPrime(10, 12);
        _q = primeNumberGen.GetNewPrime(15, 18);
        _n = _p * _q;
        _phiN = (_p - 1) * (_q - 1);
    }
    
    //Setting E to 3 for initial effort, refactor
    private void SelectE(int p, int q, int n)
    {
        _e = 3;
    }


    //https://www.di-mgt.com.au/euclidean.html#extendedeuclidean
    private void CalculateD(int v,int u)
    {
        int inv, u1, u3, v1, v3, t1, t3, q;
        int iter;
        /* Step X1. Initialise */
        u1 = 1;
        u3 = u;
        v1 = 0;
        v3 = v;
        /* Remember odd/even iterations */
        iter = 1;
        /* Step X2. Loop while v3 != 0 */
        while (v3 != 0)
        {
            /* Step X3. Divide and "Subtract" */
            q = u3 / v3;
            t3 = u3 % v3;
            t1 = u1 + q * v1;
            /* Swap */
            u1 = v1; v1 = t1; u3 = v3; v3 = t3;
            iter = -iter;
        }
        /* Make sure u3 = gcd(u,v) == 1 */
        if (u3 != 1)
            Console.WriteLine("No modular inverse exists");
        /* Ensure a positive result */
        if (iter < 0)
            _d = v - u1;
        else
            _d = u1;
    }
    public (int, int) BroadcastPublicKeys()
    {
        return (_n, _e);
    }
    public int BroadcastAdddress()
    {
        return _address;
    }

    //Was hoping to keep this super simple but I think I need to use BigInteger for even small messages, cool!
    //https://stackoverflow.com/questions/40693489/c-sharp-biginteger-with-2048bits
    public int DecryptedMessage(int message)
    {
        BigInteger bigMessage = BigInteger.Pow(message, _d);
        BigInteger publicKey = _n;
        BigInteger decryptedMessage = bigMessage % publicKey;
        int response = (int)decryptedMessage;
        //TODO - translate between string and int
        return response;
    }
}
