using System.Collections.Generic;

namespace OpenSonos.LocalMusicServer.Browsing.MusicRepositories
{
    public interface ISearchProvider
    {
        List<string> Search(string query);
    }
}