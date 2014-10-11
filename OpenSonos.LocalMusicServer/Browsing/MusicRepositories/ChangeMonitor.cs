using System;
using System.IO;

namespace OpenSonos.LocalMusicServer.Browsing.MusicRepositories
{
    public class ChangeMonitor : IMonitorTheFileSystemForChanges
    {
        private readonly FileSystemWatcher _changeMonitor;
        private Action _onChange;
        
        public ChangeMonitor()
        {
            _changeMonitor = new FileSystemWatcher
            {
                IncludeSubdirectories = true,
                InternalBufferSize = 65536,
            };

            _changeMonitor.Changed += SourceModified;
            _changeMonitor.Created += SourceModified;
            _changeMonitor.Deleted += SourceModified;
            _changeMonitor.Renamed += SourceModified;
        }

        public void StartMonitoring(string path, Action onChange)
        {
            _onChange = onChange;
            _changeMonitor.Path = path;
            _changeMonitor.EnableRaisingEvents = true;
        }

        private void SourceModified(object sender, FileSystemEventArgs fileSystemEventArgs)
        {
            _onChange = _onChange ?? (() => { });
            _onChange();
        }
    }
}