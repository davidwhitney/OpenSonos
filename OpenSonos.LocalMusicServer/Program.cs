using System;
using System.Configuration;
using System.Threading.Tasks;
using OpenSonos.LocalMusicServer.MusicDatabase;

namespace OpenSonos.LocalMusicServer
{
    class Program
    {
        public static void Main(string[] args)
        {
            var baseUrl = ConfigurationManager.AppSettings["baseUrl"];
            var musicShare = ConfigurationManager.AppSettings["musicShare"];

            var singleRepository = new FlatFileMusicCatalogue(musicShare);
            SmbMusicServer.MusicRepository = () => singleRepository;

            Server.ImplementedBy<SmbMusicServer>()
                  .HostedAt(new Uri(baseUrl))
                  .Open();

            Task.Run(() => { Players.Discover(); });
            
            Console.ReadLine();
        }
    }
}
