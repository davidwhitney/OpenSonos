using System;
using System.Collections.Generic;
using OpenSonos.LocalMusicServer.Browsing;
using OpenSonos.LocalMusicServer.MusicDatabase;
using OpenSonos.SonosServer;
using OpenSonos.SonosServer.Metadata;

namespace OpenSonos.LocalMusicServer
{
    public class SmbMusicServer : ServerBase
    {
        public static Func<IMusicRepository> MusicRepository { get; set; }

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
            var results = MusicRepository().GetResources(new SonosId(request.id));

            return new getMetadataResponse
            {
                getMetadataResult = results.DirectoryToSonosResponse(request.index, request.count)
            };
        }

        public override getExtendedMetadataResponse GetExtendedMetadata(getExtendedMetadataRequest request)
        {
            return new getExtendedMetadataResponse
            {
                getExtendedMetadataResult = new extendedMetadata
                {
                    Item = PhysicalResource.FromId(request.id).ToMediaMetadata()
                }
            };
        }

        public override getMediaMetadataResponse GetMediaMetadata(getMediaMetadataRequest request)
        {
            return new getMediaMetadataResponse
            {
                getMediaMetadataResult = new getMediaMetadataResponseGetMediaMetadataResult
                {
                    Items = new object[]
                    {
                        PhysicalResource.FromId(request.id).ToMediaMetadata()
                    },
                    ItemsElementName = new []
                    {
                        ItemsChoiceType.mediaMetadata, 
                    }
                }
            };
        }

        public override getMediaURIResponse GetMediaUri(getMediaURIRequest request)
        {
            return new getMediaURIResponse
            {
                getMediaURIResult = MusicRepository().BuildUriForId(new SonosId(request.id))
            };
        }

        public override getLastUpdateResponse GetLastUpdate(getLastUpdateRequest request)
        {
            return new getLastUpdateResponse
            {
                getLastUpdateResult = new lastUpdate
                {
                    catalog = DateTime.UtcNow.Ticks.ToString(),
                    favorites = "1"
                }
            };
        }

        public override searchResponse Search(searchRequest request)
        {
            var results = MusicRepository().Search(request.term);
            return new searchResponse
            {
                searchResult = results.DirectoryToSonosResponse(request.index, request.count)
            };
        }
    }
}