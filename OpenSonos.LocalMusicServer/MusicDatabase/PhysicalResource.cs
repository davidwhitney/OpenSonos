using System.Linq;
using OpenSonos.LocalMusicServer.Browsing;
using OpenSonos.LocalMusicServer.Compression;

namespace OpenSonos.LocalMusicServer.MusicDatabase
{
    public abstract class PhysicalResource : IRepresentAResource
    {
        public SonosIdentifier Identifier { get; private set; }
        public string DisplayName { get { return Parts.Last(); } }
        public string[] Parts { get { return Identifier.Path.Split('\\'); } }

        protected PhysicalResource(string path)
        {
            Identifier = new SonosIdentifier(path);
        }

        public static PhysicalResource FromId(string id)
        {
            return FromId(SonosIdentifier.FromRequestId(id));
        }

        public static PhysicalResource FromId(SonosIdentifier identifier)
        {
            return identifier.IsDirectory 
                ? (PhysicalResource) new Container(identifier.Path) 
                : new MusicFile(identifier.Path);
        }
    }
}