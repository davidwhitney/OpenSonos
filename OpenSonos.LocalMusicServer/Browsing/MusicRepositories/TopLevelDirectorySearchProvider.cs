using System.Collections.Generic;
using System.IO;
using System.Linq;
using OpenSonos.LocalMusicServer.Bootstrapping;

namespace OpenSonos.LocalMusicServer.Browsing.MusicRepositories
{
    public class TopLevelDirectorySearchProvider : ISearchProvider
    {
        private readonly ServerConfiguration _config;

        public TopLevelDirectorySearchProvider(ServerConfiguration config)
        {
            _config = config;
        }

        public List<string> Search(string query)
        {
            return string.IsNullOrWhiteSpace(query) 
                ? new List<string>() 
                : Directory.GetDirectories(_config.MusicShare, query + "*").ToList();
        }
    }
}