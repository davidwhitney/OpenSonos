using System;
using System.ServiceModel;
using OpenSonos.LocalMusicServer.Bootstrapping;
using SimpleServices;

namespace OpenSonos.LocalMusicServer.Smapi
{
    public class SmapiSoapServiceBootstrapper : IWindowsService
    {
        public ApplicationContext AppContext { get; set; }

        private readonly ServiceHost _server;

        public SmapiSoapServiceBootstrapper(ServerBuilder serverBuilder, ServerConfiguration config)
        {
            _server = serverBuilder.HostedAt(new Uri(config.BaseUrl + ":" + config.BasePort));
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