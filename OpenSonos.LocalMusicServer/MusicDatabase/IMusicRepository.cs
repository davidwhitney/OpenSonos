using System.Collections.Generic;
using OpenSonos.LocalMusicServer.Browsing;

namespace OpenSonos.LocalMusicServer.MusicDatabase
{
    public interface IMusicRepository
    {
        string BuildUriForId(SonosId id);
        List<IRepresentAResource> GetResources(SonosId id);
        List<IRepresentAResource> Search(string query);
    }
}