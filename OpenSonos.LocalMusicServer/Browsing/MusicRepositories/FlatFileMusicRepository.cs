using System;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using Ninject.Activation;
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
			var id = identifier == "root"
				? SonosIdentifier.Default(_config.MusicShare)
				: _identityStore.FromRequestId(identifier);

			if (id == null)
			{
				throw new ArgumentException("Unrecognised identifier '{0}' requested. Sonos player has cached an expired key.");
			}

			return GetResources(id);
		}

	    private ResourceCollection GetResources(SonosIdentifier identifier)
        {
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