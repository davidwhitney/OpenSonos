using System;
using System.Configuration;
using System.Threading.Tasks;
using OpenSonos.LocalMusicServer.Browsing;
using OpenSonos.LocalMusicServer.Compression;
using OpenSonos.LocalMusicServer.MusicDatabase;

namespace OpenSonos.LocalMusicServer
{
    class Program
    {
        public static void Main(string[] args)
        {
            var baseUrl = ConfigurationManager.AppSettings["baseUrl"];
            var musicShare = ConfigurationManager.AppSettings["musicShare"];

            var identityProvider = new IdentityProvider(new Gzip());
            var singleRepository = new FlatFileMusicCatalogue(musicShare, identityProvider);
            
            SmbMusicServer.MusicRepository = () => singleRepository;
            SmbMusicServer.IdentityProvider = () => identityProvider;

            Server.ImplementedBy<SmbMusicServer>()
                  .HostedAt(new Uri(baseUrl))
                  .Open();

            Task.Run(() => { Players.Discover(); });
            
            Console.ReadLine();
        }
    }
}
