namespace OpenSonos.LocalMusicServer.MusicDatabase
{
    public interface IRepresentAResource
    {
        string Id { get; }
        string DisplayName { get; }
    }
}