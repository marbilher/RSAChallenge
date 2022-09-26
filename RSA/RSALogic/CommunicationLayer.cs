using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSALogic
{
    //Class is intended to mimick a middle party used to send messages between two parties
    public class CommunicationLayer
    {
        Dictionary<int, RSAReceiver> _receivers = new Dictionary<int, RSAReceiver>();
        public void BroadcastReceivers()
        {
            foreach (KeyValuePair<int, RSAReceiver> entry in _receivers)
            {
                Console.WriteLine("Receiever found at: " + entry.Key + " with public keys: " + entry.Value.BroadcastPublicKeys());
            }
        }
        public (int, int) BroadcastReceiverPublicKeys(int address)
        {
            return _receivers[address].BroadcastPublicKeys();
        }
        public int BroadcastReceiverAddress()
        {
            return _receivers.Keys.First();
        }
        public void RegisterReceiver(RSAReceiver receiver)
        {

            _receivers[receiver.BroadcastAdddress()] = receiver;
        }

        public int ProcessRequest(int address, int message)
        {
            if (_receivers.ContainsKey(address))
            {
                return _receivers[address].DecryptedMessage(message);
            }
            else
            {
                {
                    Console.WriteLine("No receiver found at address: " + address);
                    return -1;
                }
            }
        }
    }
}