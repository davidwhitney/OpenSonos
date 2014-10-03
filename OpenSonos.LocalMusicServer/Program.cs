using System;

namespace OpenSonos.LocalMusicServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var uri = new Uri("http://localhost:8000");
            var path = "sonos-api";

            Server.ImplementedBy<LanMusicServer>()
                  .HostedAt(uri, path)
                  .Open();

            Console.WriteLine("Hosting Sonos API at {0}{1}", uri, path);
            Console.ReadLine();
        }
    }
}
