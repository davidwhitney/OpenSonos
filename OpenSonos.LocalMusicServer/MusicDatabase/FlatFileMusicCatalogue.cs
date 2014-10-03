using System.Collections.Generic;
using System.IO;
using System.Linq;
using OpenSonos.LocalMusicServer.Browsing;

namespace OpenSonos.LocalMusicServer.MusicDatabase
{
    public class FlatFileMusicCatalogue
    {
        public List<DirectoryEntry> GetCollection(SonosId id)
        {
            var dr = new List<DirectoryEntry>();

            if (id.IsDirectory)
            {
                dr.AddRange(Directory.GetDirectories(id.RequestedPath).Select(subdir => new DirectoryEntry { IsDirectory = true, Path = subdir }));
                dr.AddRange(Directory.GetFiles(id.RequestedPath).Select(subdir => new DirectoryEntry { Path = subdir }));
            }

            return dr;
        }
    }
}