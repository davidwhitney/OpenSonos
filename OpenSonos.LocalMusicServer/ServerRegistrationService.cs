using System;
using OpenSonos.LocalMusicServer.Bootstrapping;
using OpenSonos.LocalMusicServer.DiscoveryAndRegistration;
using SimpleServices;

namespace OpenSonos.LocalMusicServer
{
    public class ServerRegistrationService : IWindowsService 
    {
        public ApplicationContext AppContext { get; set; }
        private readonly PlayerWebInterface _webInterface;
        private readonly ServerConfiguration _config;

        public ServerRegistrationService(PlayerWebInterface webInterface, ServerConfiguration config)
        {
            _webInterface = webInterface;
            _config = config;
        }

        public void Start(string[] args)
        {
            var sync = new object();
            var registeredYet = false;

            Players.Discover(_config.ServerIp, sonosPlayer =>
            {
                lock (sync)
                {
                    if (registeredYet)
                    {
                        return;
                    }

                    registeredYet = _webInterface.RegisterServer(sonosPlayer, _config.ServerIp).Result;

                    if (registeredYet)
                    {
                        Console.WriteLine("Autoregistered server with player " + sonosPlayer.Address);
                    }
                }
            });
        }

        public void Stop()
        {
        }

    }
}