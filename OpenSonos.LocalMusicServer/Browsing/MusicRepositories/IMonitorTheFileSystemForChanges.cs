using System;

namespace OpenSonos.LocalMusicServer.Browsing.MusicRepositories
{
    public interface IMonitorTheFileSystemForChanges
    {
        void StartMonitoring(string path, Action onChange);
    }
}