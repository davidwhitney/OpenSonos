using System.Net;

namespace OpenSonos
{
    public class SonosPlayer
    {
        public IPAddress Address { get; set; }

        public SonosPlayer(string address)
        {
            Address = IPAddress.Parse(address);
        }
    }
}