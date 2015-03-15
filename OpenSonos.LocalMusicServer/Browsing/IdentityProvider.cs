using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using OpenSonos.LocalMusicServer.Bootstrapping;

namespace OpenSonos.LocalMusicServer.Browsing
{
    public class IdentityProvider : IIdentityProvider
    {
        private readonly IIdentiyBuilder _hasher;
        private readonly ServerConfiguration _config;
	    private readonly ConcurrentDictionary<string, SonosIdentifier> _pathToGuid;

        public IdentityProvider(ServerConfiguration config, IIdentiyBuilder hasher)
        {
			_pathToGuid = new ConcurrentDictionary<string, SonosIdentifier>();
	        _config = config;
            _hasher = hasher;
        }

	    public IdentityProvider(ServerConfiguration config, IIdentiyBuilder hasher, IEnumerable<KeyValuePair<string, SonosIdentifier>> backingStore)
			: this(config, hasher)
        {
	        if (backingStore == null)
            {
                return;
            }

            foreach (var item in backingStore)
            {
                _pathToGuid.TryAdd(item.Key, item.Value);
            }
        }

        public SonosIdentifier IdFor(string path)
        {
            if (_pathToGuid.ContainsKey(path))
            {
                return _pathToGuid[path];
            }

            var identifier = new SonosIdentifier
            {
                Id = _hasher.HashPath(path),
                Path = path
            };

            _pathToGuid.TryAdd(path, identifier);
            return identifier;
        }

        public SonosIdentifier FromRequestId(string requestedId)
        {
            return requestedId == "root"
                ? SonosIdentifier.Default(_config.MusicShare)
                : _pathToGuid.SingleOrDefault(x => x.Value.Id == requestedId).Value;
        }
    }
}