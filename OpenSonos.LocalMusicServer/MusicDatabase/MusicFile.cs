using OpenSonos.LocalMusicServer.Browsing;

namespace OpenSonos.LocalMusicServer.MusicDatabase
{
    public class MusicFile : PhysicalResource
    {
        public MusicFile(SonosIdentifier path) : base(path)
        {
        }
    }
}