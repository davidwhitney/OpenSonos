using System;
using System.Collections.Generic;
using OpenSonos.SonosServer;
using OpenSonos.SonosServer.Metadata;

namespace OpenSonos.LocalMusicServer
{
    public class LanMusicServer : ServerBase
    {
        public override Presentation GetPresentationMaps()
        {
            return new Presentation
            {
                PresentationMaps = new List<PresentationMap>
                {
                    PresentationMap.DefaultSonosSearch()
                }
            };
        }

        public override getSessionIdResponse GetSessionId(getSessionIdRequest request)
        {
            return new getSessionIdResponse("1");
        }

        public override getMetadataResponse GetMetadata(getMetadataRequest request)
        {
            throw new NotImplementedException();
        }

        public override getExtendedMetadataResponse GetExtendedMetadata(getExtendedMetadataRequest request)
        {
            throw new NotImplementedException();
        }

        public override getMediaMetadataResponse GetMediaMetadata(getMediaMetadataRequest request)
        {
            throw new NotImplementedException();
        }

        public override getMediaURIResponse GetMediaUri(getMediaURIRequest request)
        {
            throw new NotImplementedException();
        }

        public override searchResponse Search(searchRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
