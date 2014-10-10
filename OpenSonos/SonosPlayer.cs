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

        private static readonly SonosPlayer NoPlayer = new SonosPlayer("0.0.0.0");
        public static SonosPlayer None { get { return NoPlayer; } }
    }
}