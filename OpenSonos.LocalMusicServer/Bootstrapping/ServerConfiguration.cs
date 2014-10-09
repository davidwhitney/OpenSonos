using System.Net;

namespace OpenSonos.LocalMusicServer.Bootstrapping
{
    public class ServerConfiguration
    {
        public string BaseUrl { get; set; }
        public string BasePort { get; set; }
        public string MusicShare { get; set; }
        public IPAddress ServerIp { get; set; }

        public string ServerRoot { get { return "http://" + ServerIp + ":" + BasePort; } }

    }
}