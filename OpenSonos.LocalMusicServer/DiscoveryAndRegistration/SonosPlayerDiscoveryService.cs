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
            var registeredYet = false;

            Players.Discover(_config.ServerIp, sonosPlayer =>
            {
                if (registeredYet)
                {
                    return;
                }

                registeredYet = _webInterface.RegisterServer(sonosPlayer, _config.ServerIp).Result;
            });
        }

        public void Stop()
        {
        }

    }
}