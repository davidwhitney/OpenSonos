using System;

namespace OpenSonos.LocalMusicServer.Browsing
{
    public class SonosIdentifier
    {
        public string Id { get; set; }
        public string Path { get; set; }

        public bool IsDirectory
        {
            get { return Path == null || !Path.EndsWith(".mp3"); }
        }

	    public string Uri
	    {
		    get { return "x-file-cifs:" + Path.Replace("\\", "/"); }
	    }

	    public SonosIdentifier()
        {
            Id = string.Empty;
            Path = string.Empty;
        }

	    public static SonosIdentifier Default(string rootPath)
	    {
		    return new SonosIdentifier {Id = Guid.Empty.ToString(), Path = rootPath};
	    }
    }
}