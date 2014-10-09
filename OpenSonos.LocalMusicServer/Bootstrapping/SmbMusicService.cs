using System;
using System.Configuration;
using System.ServiceModel;
using OpenSonos.LocalMusicServer.Browsing;
using OpenSonos.LocalMusicServer.MusicDatabase;
using OpenSonos.LocalMusicServer.Smapi;
using SimpleServices;

namespace OpenSonos.LocalMusicServer.Bootstrapping
{
    public class SmbMusicService : IWindowsService
    {
        public ApplicationContext AppContext { get; set; }

        private readonly ServiceHost _server;

        public SmbMusicService()
        {
            var baseUrl = ConfigurationManager.AppSettings["baseUrl"];
            var musicShare = ConfigurationManager.AppSettings["musicShare"];

            var identityProvider = new GuidIdentityProvider();
            var singleRepository = new FlatFileMusicCatalogue(musicShare, identityProvider);

            SmbMusicServer.MusicRepository = () => singleRepository;
            SmbMusicServer.IdentityProvider = () => identityProvider;

            _server = Server.ImplementedBy<SmbMusicServer>().HostedAt(new Uri(baseUrl));
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