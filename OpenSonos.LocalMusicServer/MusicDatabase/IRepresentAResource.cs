using OpenSonos.LocalMusicServer.Browsing;

namespace OpenSonos.LocalMusicServer.MusicDatabase
{
    public interface IRepresentAResource
    {
        SonosIdentifier Identifier { get; }
        string DisplayName { get; }
    }
}