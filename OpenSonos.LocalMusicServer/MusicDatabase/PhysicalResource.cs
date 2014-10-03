using System.Linq;
using OpenSonos.LocalMusicServer.Browsing;
using OpenSonos.LocalMusicServer.Compression;

namespace OpenSonos.LocalMusicServer.MusicDatabase
{
    public abstract class PhysicalResource : IRepresentAResource
    {
        public string Path { get; set; }
        public string Id { get { return Gzip.CompressString(Path); } }
        public string DisplayName { get { return Parts.Last(); } }
        public string[] Parts { get { return Path.Split('\\'); } }

        protected PhysicalResource(string path)
        {
            Path = path;
        }

        public static PhysicalResource FromId(string id)
        {
            return FromId(new SonosId(id));
        }

        public static PhysicalResource FromId(SonosId id)
        {
            return id.IsDirectory 
                ? (PhysicalResource) new Container(id.RequestedPath) 
                : new MusicFile(id.RequestedPath);
        }
    }
}