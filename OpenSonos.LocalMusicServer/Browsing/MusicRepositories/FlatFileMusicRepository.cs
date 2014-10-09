using System.Collections.Generic;
using System.IO;
using System.Linq;
using OpenSonos.LocalMusicServer.Bootstrapping;

namespace OpenSonos.LocalMusicServer.Browsing.MusicRepositories
{
    public class FlatFileMusicRepository : IMusicRepository
    {
        private readonly IIdentityProvider _converter;
        private readonly ServerConfiguration _config;

        public FlatFileMusicRepository(ServerConfiguration config, IIdentityProvider converter)
        {
            _config = config;
            _converter = converter;
        }

        public List<IRepresentAResource> GetResources(SonosIdentifier identifier)
        {
            if (!identifier.IsDirectory)
            {
                return new List<IRepresentAResource>();
            }

            var directoryEntries = new List<IRepresentAResource>();
            var path = _config.MusicShare + identifier.Path;
            directoryEntries.AddRange(Directory.GetDirectories(path).Select(ToContainer));
            directoryEntries.AddRange(Directory.GetFiles(path, "*.mp3", SearchOption.TopDirectoryOnly).Select(ToMusicFile));
            return directoryEntries;
        }

        private Container ToContainer(string subdir)
        {
            var p = subdir.Replace(_config.MusicShare, "");
            var id = _converter.FromPath(p);
            return new Container(id);
        }

        private MusicFile ToMusicFile(string subdir)
        {
            var p = subdir.Replace(_config.MusicShare, "");
            var id = _converter.FromPath(p);
            return new MusicFile(id);
        }

        public List<IRepresentAResource> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return new List<IRepresentAResource>();
            }

            var directoryEntries = new List<IRepresentAResource>();
            var @out = Directory.GetDirectories(_config.MusicShare, query + "*");
            directoryEntries.AddRange(@out.Select(ToContainer));

            return directoryEntries;
        }

        public string BuildUriForId(SonosIdentifier identifier)
        {
            return "x-file-cifs:" + (_config.MusicShare + identifier.Path).Replace("\\", "/");
        }
    }
}