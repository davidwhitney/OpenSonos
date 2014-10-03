using System;
using System.Threading.Tasks;

namespace OpenSonos.LocalMusicServer
{
    class Program
    {
        public static void Main(string[] args)
        {
            Server.ImplementedBy<LanMusicServer>()
                  .HostedAt(new Uri("http://localhost:8000"))
                  .Open();

            Task.Run(() => { Players.Discover(); });
            
            Console.ReadLine();
        }
    }
}
