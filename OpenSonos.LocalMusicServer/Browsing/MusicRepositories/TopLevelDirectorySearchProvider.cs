using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using OpenSonos.LocalMusicServer.Bootstrapping;

namespace OpenSonos.LocalMusicServer.Browsing.MusicRepositories
{
    public class TopLevelDirectorySearchProvider : ISearchProvider
    {
        private readonly ServerConfiguration _config;
        private readonly IFileSystem _fs;

        public TopLevelDirectorySearchProvider(ServerConfiguration config, IFileSystem fs)
        {
            _config = config;
            _fs = fs;
        }

        public List<string> Search(string query)
        {
            return string.IsNullOrWhiteSpace(query) 
                ? new List<string>() 
                : _fs.Directory.GetDirectories(_config.MusicShare, query + "*").ToList();
        }
    }
}