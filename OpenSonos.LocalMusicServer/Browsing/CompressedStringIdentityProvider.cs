using System;
using OpenSonos.LocalMusicServer.Compression;

namespace OpenSonos.LocalMusicServer.Browsing
{
    public class CompressedStringIdentityProvider : IIdentityProvider
    {
        private readonly IIdentityCompressionStrategy _identityCompressionStrategy;

        public CompressedStringIdentityProvider(IIdentityCompressionStrategy identityCompressionStrategy)
        {
            _identityCompressionStrategy = identityCompressionStrategy;
        }

        public SonosIdentifier FromPath(string path)
        {
            var id = _identityCompressionStrategy.CompressString(path);

            if (id.Length > 128)
            {
                throw new Exception("Compressed path is too for Sonos systems.");
            }

            return new SonosIdentifier
            {
                Id = id,
                Path = path
            };
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
            }

            return s;
        }
    }
}