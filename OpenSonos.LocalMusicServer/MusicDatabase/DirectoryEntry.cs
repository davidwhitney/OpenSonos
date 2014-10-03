using OpenSonos.LocalMusicServer.Compression;

namespace OpenSonos.LocalMusicServer.MusicDatabase
{
    public class DirectoryEntry
    {
        public bool IsDirectory { get; set; }
        public string Path { get; set; }
        public string Id { get { return Gzip.CompressString(Path); } }
        public string[] Parts { get { return Path.Split('\\'); } }

        public DirectoryEntry(string path, bool isDirectory = false)
        {
            Path = path;
            IsDirectory = isDirectory;
        }
    }
}