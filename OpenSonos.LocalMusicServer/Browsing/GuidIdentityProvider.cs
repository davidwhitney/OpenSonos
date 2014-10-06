using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace OpenSonos.LocalMusicServer.Browsing
{
    public class GuidIdentityProvider : IIdentityProvider
    {
        private readonly IDictionary<string, SonosIdentifier> _pathToGuid;

        public GuidIdentityProvider(IDictionary<string, SonosIdentifier> backingStore = null)
        {
            _pathToGuid = backingStore ?? new ConcurrentDictionary<string, SonosIdentifier>();
        }

        public SonosIdentifier FromPath(string path)
        {
            if (_pathToGuid.ContainsKey(path))
            {
                return _pathToGuid[path];
            }

            var identifier = new SonosIdentifier
            {
                Id = Guid.NewGuid().ToString(),
                Path = path
            };

            _pathToGuid.Add(path, identifier);
            return identifier;
        }

        public SonosIdentifier FromRequestId(string requestedId)
        {
            var reverseMatch = _pathToGuid.SingleOrDefault(x => x.Value.Id == requestedId);

            if (reverseMatch.Value == null)
            {
                return new SonosIdentifier();
            }

            return reverseMatch.Value;
        }
    }
}