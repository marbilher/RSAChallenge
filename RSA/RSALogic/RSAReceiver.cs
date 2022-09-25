

namespace RSALogic;

//RSAReceiver should have two publicly accessible methods, GetPublicKey and ReceiveEncryptedData
//RSAReceiver should not be modified after instantiation as once a public key has been distributed, we do not want change any internal values.
public class RSAReceiver
{
    //in actual use cases these will > 1024 bit integers
    private int _p;
    private int _q;
    private int _n; //public key, n = p * q
    private int _e; //public key exponent, e = relative prime of ϕ(pq)=(p−1)(q−1) 
    private int _d; //private key
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
        CalculateD(_e, _n);
        Console.WriteLine("Receiver public key: " + _n + ", " + _e + "Receiver private key: " + _d);
    }

    private void GenerateN(PrimeNumberGenerator primeNumberGen)
    {
        _p = primeNumberGen.GetNewPrime(3, 100);
        _q = primeNumberGen.GetNewPrime(3, 100);
        _n = _p * _q;
    }
    
    //Setting E to 3 for initial effort
    //Refactor to: ϕ(pq)=(p−1)(q−1), also read up on 65537
    private void SelectE(int p, int q, int n)
    {
        _e = 3;
    }
    
    //Update with extended euclidean algorithm
    private void CalculateD(int e, int n)
    {
        int res;
        for (int i = 0; i < 100; i++)
        {
            res = ((n * i) + 1) / e;
            if (res == e)
            {
                _d = res;
                break;
            }
        }
    }
    
    public (int, int) GetPublicKey()
    {
        return (_n, _e);
    }
}
