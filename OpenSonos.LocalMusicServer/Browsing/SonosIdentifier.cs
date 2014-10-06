namespace OpenSonos.LocalMusicServer.Browsing
{
    public class SonosIdentifier
    {
        public string Id { get; set; }
        public string Path { get; set; }

        public bool IsDirectory
        {
            get
            {
                return Path == null || !Path.EndsWith(".mp3");
            }
        }

        public SonosIdentifier()
        {
            Id = string.Empty;
            Path = string.Empty;
        }
    }
}