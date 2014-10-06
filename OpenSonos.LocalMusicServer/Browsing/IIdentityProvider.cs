namespace OpenSonos.LocalMusicServer.Browsing
{
    public interface IIdentityProvider
    {
        SonosIdentifier FromPath(string path);
        SonosIdentifier FromRequestId(string requestedId);
    }
}