using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace OpenSonos.LocalMusicServer.Bootstrapping
{
    public static class ServerConfigurationFactory
    {
        public static ServerConfiguration LoadConfiguration()
        {
            var appSetting = new System.Configuration.Abstractions.ConfigurationManager();
            var cfg = appSetting.AppSettings.Map<ServerConfiguration>();
            cfg.ServerIp = GetIp();
            return cfg;
        }

        private static IPAddress GetIp()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            return host.AddressList.First(x => x.AddressFamily == AddressFamily.InterNetwork);
        }
    }
}