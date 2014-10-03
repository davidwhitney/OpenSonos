using System.Collections.Generic;
using System.IO;
using System.Linq;
using OpenSonos.LocalMusicServer.Browsing;

namespace OpenSonos.LocalMusicServer.MusicDatabase
{
    public class FlatFileMusicCatalogue : IMusicRepository
    {
        private readonly string _root;

        public FlatFileMusicCatalogue(string root)
        {
            _root = root;
        }

        public List<IRepresentAResource> GetResources(SonosId id)
        {
            if (!id.IsDirectory)
            {
                return new List<IRepresentAResource>();
            }

            var directoryEntries = new List<IRepresentAResource>();
            var path = _root + id.RequestedPath;
            directoryEntries.AddRange(Directory.GetDirectories(path).Select(subdir => new Container(subdir.Replace(_root, ""))));
            directoryEntries.AddRange(Directory.GetFiles(path, "*.mp3", SearchOption.TopDirectoryOnly).Select(subdir => new MusicFile(subdir.Replace(_root, ""))));
            return directoryEntries;
        }

        public List<IRepresentAResource> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return new List<IRepresentAResource>();
            }

            var directoryEntries = new List<IRepresentAResource>();
            directoryEntries.AddRange(Directory.GetFiles(_root, "*" + query + "*", SearchOption.TopDirectoryOnly).Select(subdir => new MusicFile(subdir.Replace(_root, ""))));
            return directoryEntries;
        }

        public string BuildUriForId(SonosId id)
        {
            return "x-file-cifs:" + (_root + id.RequestedPath).Replace("\\", "/");
        }
    }
}