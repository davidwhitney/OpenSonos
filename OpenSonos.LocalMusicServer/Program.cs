using System;

namespace OpenSonos.LocalMusicServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Server.ImplementedBy<LanMusicServer>()
                  .HostedAt(new Uri("http://localhost:8000"))
                  .Open();
            
            Console.ReadLine();
        }
    }
}
