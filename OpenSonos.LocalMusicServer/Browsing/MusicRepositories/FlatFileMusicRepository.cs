using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using OpenSonos.LocalMusicServer.Bootstrapping;

namespace OpenSonos.LocalMusicServer.Browsing.MusicRepositories
{
    public class FlatFileMusicRepository : IMusicRepository
    {
        private readonly IIdentityProvider _converter;
        private readonly ISearchProvider _searchProvider;
        private readonly IFileSystem _fs;
        private readonly ServerConfiguration _config;

        public DateTime LastUpdate { get; set; }

        public FlatFileMusicRepository(ServerConfiguration config, IIdentityProvider converter, ISearchProvider searchProvider, IFileSystem fs)
        {
            _config = config;
            _converter = converter;
            _searchProvider = searchProvider;
            _fs = fs;
            ConfigureChangeMonitoring();
        }

        public List<IRepresentAResource> GetResources(SonosIdentifier identifier)
        {
            if (!identifier.IsDirectory)
            {
                return new List<IRepresentAResource>();
            }

            var directoryEntries = new List<IRepresentAResource>();
            var path = _config.MusicShare + identifier.Path;
            directoryEntries.AddRange(_fs.Directory.GetDirectories(path).Select(ToPhysicalResource<Container>));
            directoryEntries.AddRange(_fs.Directory.GetFiles(path, "*.mp3", SearchOption.TopDirectoryOnly).Select(ToPhysicalResource<MusicFile>));
            return directoryEntries;
        }

        public List<IRepresentAResource> Search(string query)
        {
            var directoryEntries = new List<IRepresentAResource>();
            var pathsFound = _searchProvider.Search(query);
            directoryEntries.AddRange(pathsFound.Select(ToPhysicalResource<Container>));
            return directoryEntries;
        }

        public string BuildUriForId(SonosIdentifier identifier)
        {
            return "x-file-cifs:" + (_config.MusicShare + identifier.Path).Replace("\\", "/");
        }
        
        private void ConfigureChangeMonitoring()
        {
            LastUpdate = DateTime.UtcNow;

            var changeMonitor = new FileSystemWatcher
            {
                IncludeSubdirectories = true,
                InternalBufferSize = 65536,
                Path = _config.MusicShare
            };

            changeMonitor.Changed += SourceModified;
            changeMonitor.Created += SourceModified;
            changeMonitor.Deleted += SourceModified;
            changeMonitor.Renamed += SourceModified;
            changeMonitor.EnableRaisingEvents = true;
        }

        private void SourceModified(object sender, FileSystemEventArgs fileSystemEventArgs)
        {
            LastUpdate = DateTime.UtcNow;
        }

        private TResourceType ToPhysicalResource<TResourceType>(string subdir) where TResourceType: PhysicalResource, new()
        {
            var pathWithoutShareRoot = subdir.Replace(_config.MusicShare, "");
            return new TResourceType {Identifier = _converter.FromPath(pathWithoutShareRoot)};
        }
    }
}