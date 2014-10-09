using System.Collections.Generic;

namespace OpenSonos.LocalMusicServer.Browsing
{
    public interface IMusicRepository
    {
        string BuildUriForId(SonosIdentifier identifier);
        List<IRepresentAResource> GetResources(SonosIdentifier identifier);
        List<IRepresentAResource> Search(string query);
    }
}