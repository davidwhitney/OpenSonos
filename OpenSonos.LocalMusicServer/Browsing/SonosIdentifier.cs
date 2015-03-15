using System;

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

		public string Uri
		{
			get { return "x-file-cifs:" + Path.Replace("\\", "/"); }
		}

	    public static SonosIdentifier Random()
	    {
		    var guid = Guid.NewGuid();
		    return new SonosIdentifier
		    {
			    Id = guid.ToString(),
			    Path = string.Empty
		    };
	    }
    }
}