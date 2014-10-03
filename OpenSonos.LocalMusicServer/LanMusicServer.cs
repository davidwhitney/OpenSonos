using System;
using OpenSonos.SonosServer;

namespace OpenSonos.LocalMusicServer
{
    public class LanMusicServer : ServerBase
    {
        public override PresentationMap GetPresentationMaps()
        {
            return PresentationMap.DefaultSonosSearch();
        }

        public override getSessionIdResponse GetSessionId(getSessionIdRequest request)
        {
            return new getSessionIdResponse("1");
        }

        public override searchResponse Search(searchRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
