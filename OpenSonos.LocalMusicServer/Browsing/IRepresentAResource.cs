namespace OpenSonos.LocalMusicServer.Browsing
{
    public interface IRepresentAResource
    {
        SonosIdentifier Identifier { get; }
        string DisplayName { get; }
    }
}