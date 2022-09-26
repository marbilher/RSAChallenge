

namespace RSALogic
{
    public class Program
    {
        static void Main() {
            PrimeNumberGenerator primeGen = new PrimeNumberGenerator();
            RSAReceiver receiver = new RSAReceiver(primeGen);
            RSASender sender = new RSASender();
            CommunicationLayer commLayer = new CommunicationLayer();            
            commLayer.RegisterReceiver(receiver);
            commLayer.BroadcastReceivers();
            var targetAddress = commLayer.BroadcastReceiverAddress();
            var targetAddressKeys = commLayer.BroadcastReceiverPublicKeys(targetAddress);
            sender.sendMessage(targetAddress, targetAddressKeys, "A", commLayer);
        }
    }
}
