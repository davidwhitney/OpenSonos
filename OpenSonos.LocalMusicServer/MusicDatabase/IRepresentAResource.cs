using OpenSonos.LocalMusicServer.Browsing;

namespace OpenSonos.LocalMusicServer.MusicDatabase
{
    public interface IRepresentAResource
    {
        SonosIdentifier Identifier { get; }
        //string Id { get; }
        string DisplayName { get; }
    }
}