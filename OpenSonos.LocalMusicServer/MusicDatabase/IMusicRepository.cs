using System.Collections.Generic;
using OpenSonos.LocalMusicServer.Browsing;

namespace OpenSonos.LocalMusicServer.MusicDatabase
{
    public interface IMusicRepository
    {
        string BuildUriForId(SonosIdentifier identifier);
        List<IRepresentAResource> GetResources(SonosIdentifier identifier);
        List<IRepresentAResource> Search(string query);
    }
}