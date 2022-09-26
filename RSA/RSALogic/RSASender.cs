using System.Numerics;

namespace RSALogic
{
    public class RSASender
    {   
        public RSASender()
        {
            
        }
        //10 char limit for testing, see TextEncodeDecode
        public void sendMessage(int address, (int, int) keys, string message, CommunicationLayer commLayer)
        {
            Console.WriteLine("Processing message: " + message);
            int encodedMessage = TextEncodeDecode.EncodeMessage(message);
            var encryptedMessage = encryptMessage(encodedMessage, keys);
            Console.WriteLine("Message encrypted to: " + encryptedMessage);
            int response = commLayer.ProcessRequest(address, encryptedMessage);
            string decodedResponse = TextEncodeDecode.DecodeMessage(response);
            Console.WriteLine("Sender received and decoded: " + decodedResponse);
        }

        //Encryption
        //Raise your message to the power of E
        //Return val % N
        private int encryptMessage(int message, (int, int) keys)
        {
            BigInteger bigMessage = BigInteger.Pow(message, keys.Item2);
            BigInteger encryptedMessage = bigMessage % keys.Item1;
            return (int)encryptedMessage;
        }
    }
}