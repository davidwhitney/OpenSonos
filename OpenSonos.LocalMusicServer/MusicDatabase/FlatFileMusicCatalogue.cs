using System.Collections.Generic;
using System.IO;
using System.Linq;
using OpenSonos.LocalMusicServer.Browsing;

namespace OpenSonos.LocalMusicServer.MusicDatabase
{
    public class FlatFileMusicCatalogue : IMusicRepository
    {
        private readonly string _root;
        private readonly IIdentityProvider _converter;

        public FlatFileMusicCatalogue(string root, IIdentityProvider converter)
        {
            _root = root;
            _converter = converter;
        }

        public List<IRepresentAResource> GetResources(SonosIdentifier identifier)
        {
            if (!identifier.IsDirectory)
            {
                return new List<IRepresentAResource>();
            }

            var directoryEntries = new List<IRepresentAResource>();
            var path = _root + identifier.Path;
            directoryEntries.AddRange(Directory.GetDirectories(path).Select(ToContainer));
            directoryEntries.AddRange(Directory.GetFiles(path, "*.mp3", SearchOption.TopDirectoryOnly).Select(ToMusicFile));
            return directoryEntries;
        }

        private Container ToContainer(string subdir)
        {
            var p = subdir.Replace(_root, "");
            var id = _converter.FromPath(p);
            return new Container(id);
        }

        private MusicFile ToMusicFile(string subdir)
        {
            var p = subdir.Replace(_root, "");
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
            directoryEntries.AddRange(Directory.GetFiles(_root, "*" + query + "*", SearchOption.TopDirectoryOnly).Select(ToMusicFile));
            return directoryEntries;
        }

        public string BuildUriForId(SonosIdentifier identifier)
        {
            return "x-file-cifs:" + (_root + identifier.Path).Replace("\\", "/");
        }
    }
}