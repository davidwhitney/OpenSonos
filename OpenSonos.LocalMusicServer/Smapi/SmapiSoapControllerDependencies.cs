using System;
using OpenSonos.LocalMusicServer.Browsing;

namespace OpenSonos.LocalMusicServer.Smapi
{
    public class SmapiSoapControllerDependencies
    {
        public Guid Id { get; set; }
        public IMusicRepository MusicRepository { get; set; }
        public IIdentityProvider IdentityProvider { get; set; }

        public SmapiSoapControllerDependencies(IMusicRepository musicRepository, IIdentityProvider identityProvider)
        {
            Id = Guid.NewGuid();
            MusicRepository = musicRepository;
            IdentityProvider = identityProvider;
        }
    }
}