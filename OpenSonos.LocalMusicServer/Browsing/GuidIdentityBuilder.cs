using System;

namespace OpenSonos.LocalMusicServer.Browsing
{
    public class GuidIdentityBuilder : IIdentiyBuilder
    {
        public string HashPath(string path)
        {
            return Guid.NewGuid().ToString();
        }
    }
}