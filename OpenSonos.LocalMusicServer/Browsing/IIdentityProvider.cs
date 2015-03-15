namespace OpenSonos.LocalMusicServer.Browsing
{
    public interface IIdentityProvider
    {
        SonosIdentifier IdFor(string path);
        SonosIdentifier FromRequestId(string requestedId);
    }
}