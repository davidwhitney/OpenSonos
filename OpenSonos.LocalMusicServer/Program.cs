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

            Task.Run(() => RegisterServer());
            
            Console.ReadLine();
        }

        public static async void RegisterServer()
        {
            var players = await Players.Discover();

            Console.WriteLine("Discovered Sonos Players:" + Environment.NewLine);
            foreach (var player in players)
            {
                Console.WriteLine("\t" + player.Address);
            }
            
        }
    }
}
