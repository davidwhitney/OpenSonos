using System;
using OpenSonos.LocalMusicServer.Compression;

namespace OpenSonos.LocalMusicServer.Browsing
{
    public class IdentityProvider : IIdentityProvider
    {
        private readonly IIdentityCompressionStrategy _identityCompressionStrategy;

        public IdentityProvider(IIdentityCompressionStrategy identityCompressionStrategy)
        {
            _identityCompressionStrategy = identityCompressionStrategy;
        }

        public SonosIdentifier FromPath(string path)
        {
            var s = new SonosIdentifier
            {
                Id = _identityCompressionStrategy.CompressString(path),
                Path = path
            };

            if (s.Id.Length > 128)
            {
                throw new Exception("Compressed path is too for Sonos systems.");
            }

            return s;
        }

        public SonosIdentifier FromRequestId(string requestedId)
        {
            var s = new SonosIdentifier
            {
                Id = requestedId,
                Path = _identityCompressionStrategy.TryDecompressString(requestedId)
            };

            if (requestedId == "root" || string.IsNullOrWhiteSpace(requestedId))
            {
                s.Id = _identityCompressionStrategy.CompressString("");
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