using System.Collections.Generic;
using System.IO;
using System.Linq;
using OpenSonos.LocalMusicServer.Browsing;

namespace OpenSonos.LocalMusicServer.MusicDatabase
{
    public class FlatFileMusicCatalogue
    {
        public string Root = "\\\\redqueen\\music\\";

        public List<DirectoryEntry> GetCollection(SonosId id)
        {
            if (!id.IsDirectory)
            {
                return new List<DirectoryEntry>();
            }

            var directoryEntries = new List<DirectoryEntry>();
            var path = Root + id.RequestedPath;
            directoryEntries.AddRange(Directory.GetDirectories(path).Select(subdir => new DirectoryEntry(subdir.Replace(Root, ""), true)));
            directoryEntries.AddRange(Directory.GetFiles(path, "*.mp3", SearchOption.TopDirectoryOnly).Select(subdir => new DirectoryEntry(subdir.Replace(Root, ""))));
            return directoryEntries;
        }

        public List<DirectoryEntry> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return new List<DirectoryEntry>();
            }

            var directoryEntries = new List<DirectoryEntry>();
            directoryEntries.AddRange(Directory.GetFiles(Root, "*"+query+"*", SearchOption.TopDirectoryOnly).Select(subdir => new DirectoryEntry(subdir.Replace(Root, ""))));
            return directoryEntries;
        } 
    }
}