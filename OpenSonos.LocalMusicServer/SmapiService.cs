using System;
using System.ServiceModel;
using OpenSonos.LocalMusicServer.Bootstrapping;
using SimpleServices;

namespace OpenSonos.LocalMusicServer
{
    public class SmapiService : IWindowsService
    {
        public ApplicationContext AppContext { get; set; }

        private readonly ServiceHost _server;

        public SmapiService(LocalMusicServerFactory localMusicServerFactory, ServerConfiguration config)
        {
            _server = localMusicServerFactory.HostedAt(new Uri(config.BaseUrl + ":" + config.BasePort));
        }

        public void Start(string[] args)
        {
            _server.Open();
        }

        public void Stop()
        {
            _server.Close(new TimeSpan(0, 0, 0, 10));
        }
    }
}