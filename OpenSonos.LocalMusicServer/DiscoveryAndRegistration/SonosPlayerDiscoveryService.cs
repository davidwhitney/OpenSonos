using System.Linq;
using OpenSonos.LocalMusicServer.Bootstrapping;
using SimpleServices;

namespace OpenSonos.LocalMusicServer.DiscoveryAndRegistration
{
    public class SonosPlayerDiscoveryService : IWindowsService 
    {
        public ApplicationContext AppContext { get; set; }
        private readonly PlayerWebInterface _webInterface;
        private readonly ServerConfiguration _config;

        public SonosPlayerDiscoveryService(PlayerWebInterface webInterface, ServerConfiguration config)
        {
            _webInterface = webInterface;
            _config = config;
        }

        public void Start(string[] args)
        {
            var players = Players.Discover(_config.ServerIp);

            if (!players.Any())
            {
                return;
            }

            _webInterface.RegisterServer(players.First(), _config.ServerIp);
        }

        public void Stop()
        {
        }

    }
}