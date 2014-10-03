using System;
using System.Collections.Generic;
using OpenSonos.LocalMusicServer.Browsing;
using OpenSonos.LocalMusicServer.MusicDatabase;
using OpenSonos.SonosServer;
using OpenSonos.SonosServer.Metadata;

namespace OpenSonos.LocalMusicServer
{
    public class LanMusicServer : ServerBase
    {
        private readonly FlatFileMusicCatalogue _catalogue;

        public LanMusicServer()
        {
            _catalogue = new FlatFileMusicCatalogue();
        }

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
            var id = new SonosId(request.id);
            var results = _catalogue.GetCollection(id);

            return new getMetadataResponse
            {
                getMetadataResult = results.DirectoryToSonosResponse(request.index, request.count)
            };
        }

        public override getExtendedMetadataResponse GetExtendedMetadata(getExtendedMetadataRequest request)
        {
            var id = new SonosId(request.id);
            var entry = new DirectoryEntry(id.RequestedPath);
            return entry.ToMetaDataResponse();
        }

        public override getMediaMetadataResponse GetMediaMetadata(getMediaMetadataRequest request)
        {
            var id = new SonosId(request.id);
            var entry = new DirectoryEntry(id.RequestedPath);

            return new getMediaMetadataResponse
            {
                getMediaMetadataResult = new getMediaMetadataResponseGetMediaMetadataResult
                {
                    Items = new object[]{entry.ToMediaMetadata()},
                    ItemsElementName = new []
                    {
                        ItemsChoiceType.mediaMetadata, 
                    }
                }
            };
        }

        public override getMediaURIResponse GetMediaUri(getMediaURIRequest request)
        {
            var id = new SonosId(request.id);
            var resp = new getMediaURIResponse
            {
                getMediaURIResult = "x-file-cifs:" + "//redqueen/music/" + id.RequestedPath.Replace("\\", "/"),
            };
            return resp;
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
            var results = _catalogue.Search(request.term);
            return new searchResponse
            {
                searchResult = results.DirectoryToSonosResponse(request.index, request.count)
            };
        }
    }
}
