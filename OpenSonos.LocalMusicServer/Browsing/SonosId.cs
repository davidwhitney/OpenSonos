using OpenSonos.LocalMusicServer.Compression;

namespace OpenSonos.LocalMusicServer.Browsing
{
    public class SonosId
    {
        public string RequestedId { get; private set; }
        public string RequestedPath { get; private set; }
        public bool IsDirectory { get; private set; }

        public SonosId(string requestedId)
        {
            RequestedId = requestedId;
            RequestedPath = Gzip.TryDecompressString(requestedId);

            if (requestedId == "root")
            {
                RequestedId = Gzip.CompressString("");
                RequestedPath = "";
                IsDirectory = true;
            }

            if (RequestedPath == null || !RequestedPath.EndsWith(".mp3"))
            {
                IsDirectory = true;
            }
        }
    }
}