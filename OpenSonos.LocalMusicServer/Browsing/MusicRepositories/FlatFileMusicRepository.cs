using System;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using OpenSonos.LocalMusicServer.Bootstrapping;

namespace OpenSonos.LocalMusicServer.Browsing.MusicRepositories
{
    public class FlatFileMusicRepository : IMusicRepository
    {
        private readonly IIdentityProvider _identityStore;
        private readonly ISearchProvider _searchProvider;
        private readonly IFileSystem _fs;
        private readonly ServerConfiguration _config;

        public DateTime LastUpdate { get; set; }

        public FlatFileMusicRepository(ServerConfiguration config, IIdentityProvider identityStore, ISearchProvider searchProvider, IFileSystem fs, IMonitorTheFileSystemForChanges changeMonitor)
        {
            _config = config;
            _identityStore = identityStore;
            _searchProvider = searchProvider;
            _fs = fs;

            LastUpdate = DateTime.UtcNow;
            changeMonitor.StartMonitoring(config.MusicShare, () =>
            {
                LastUpdate = DateTime.UtcNow;
            });
        }

		public ResourceCollection GetResources(string identifier)
	    {
		    return GetResources(_identityStore.FromRequestId(identifier));
	    }

		public ResourceCollection GetResources(SonosIdentifier identifier)
        {
            if (string.IsNullOrWhiteSpace(identifier.Path))
            {
                identifier.Path = _config.MusicShare;
            }

            if (!identifier.IsDirectory)
            {
				return new ResourceCollection(identifier);
            }

            var directoryEntries = new ResourceCollection(identifier);
            directoryEntries.AddRange(_fs.Directory.GetDirectories(identifier.Path).Select(ToPhysicalResource<Container>));
            directoryEntries.AddRange(_fs.Directory.GetFiles(identifier.Path, "*.mp3", SearchOption.TopDirectoryOnly).Select(ToPhysicalResource<MusicFile>));
            return directoryEntries;
        }

		public ResourceCollection Search(string query)
        {
            var pathsFound = _searchProvider.Search(query);
			return new ResourceCollection(null, pathsFound.Select(ToPhysicalResource<Container>));
        }
		
        private TResourceType ToPhysicalResource<TResourceType>(string subdir) where TResourceType: PhysicalResource, new()
        {
            return new TResourceType { Identifier = _identityStore.IdFor(subdir) };
        }
    }
}