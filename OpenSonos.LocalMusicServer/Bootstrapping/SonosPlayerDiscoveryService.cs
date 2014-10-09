using SimpleServices;

namespace OpenSonos.LocalMusicServer.Bootstrapping
{
    public class SonosPlayerDiscoveryService : IWindowsService 
    {
        public ApplicationContext AppContext { get; set; }

        public void Start(string[] args)
        {
            Players.Discover();
        }

        public void Stop()
        {
        }

    }
}