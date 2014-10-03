using System;
using System.Threading.Tasks;
using OpenSonos.LocalMusicServer.MusicDatabase;

namespace OpenSonos.LocalMusicServer
{
    class Program
    {
        public static void Main(string[] args)
        {
            var singleRepository = new FlatFileMusicCatalogue("\\\\redqueen\\music\\");
            SmbMusicServer.MusicRepository = () => singleRepository;

            Server.ImplementedBy<SmbMusicServer>()
                  .HostedAt(new Uri("http://localhost:8000"))
                  .Open();

            Task.Run(() => { Players.Discover(); });
            
            Console.ReadLine();
        }
    }
}
