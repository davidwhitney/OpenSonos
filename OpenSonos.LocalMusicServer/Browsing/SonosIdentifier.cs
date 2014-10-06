using System;
using OpenSonos.LocalMusicServer.Compression;

namespace OpenSonos.LocalMusicServer.Browsing
{
    public class SonosIdentifier
    {
        public string Id { get; private set; }
        public string Path { get; private set; }
        public bool IsDirectory { get; private set; }

        private SonosIdentifier()
        {
        }

        public SonosIdentifier(string path)
        {
            Path = path;
            Id = Gzip.CompressString(path);

            if (path.Length > 128)
            {
                throw new Exception("Compressed path is too for Sonos systems.");
            }
        }

        public static SonosIdentifier FromRequestId(string requestedId)
        {
            var s = new SonosIdentifier
            {
                Id = requestedId, 
                Path = Gzip.TryDecompressString(requestedId)
            };

            if (requestedId == "root" || string.IsNullOrWhiteSpace(requestedId))
            {
                s.Id = Gzip.CompressString("");
                s.Path = "";
                s.IsDirectory = true;
            }

            if (s.Path == null || !s.Path.EndsWith(".mp3"))
            {
                s.IsDirectory = true;
            }

            return s;
        }
    }
}