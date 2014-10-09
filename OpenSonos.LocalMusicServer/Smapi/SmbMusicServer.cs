using System;
using OpenSonos.LocalMusicServer.Browsing;
using OpenSonos.LocalMusicServer.MusicDatabase;
using OpenSonos.SonosServer;
using OpenSonos.SonosServer.Metadata;

namespace OpenSonos.LocalMusicServer.Smapi
{
    public class SmbMusicServer : ServerBase
    {
        public static Func<IMusicRepository> MusicRepository { get; set; }
        public static Func<IIdentityProvider> IdentityProvider { get; set; }

        public override Presentation GetPresentationMaps()
        {
            return new Presentation(PresentationMap.DefaultSonosSearch());
        }

        public override getSessionIdResponse GetSessionId(getSessionIdRequest request)
        {
            return new getSessionIdResponse("1");
        }

        public override getMetadataResponse GetMetadata(getMetadataRequest request)
        {
            var id = IdentityProvider().FromRequestId(request.id);
            var results = MusicRepository().GetResources(id);
            return new getMetadataResponse(results.DirectoryToSonosResponse(request.index, request.count));
        }

        public override getExtendedMetadataResponse GetExtendedMetadata(getExtendedMetadataRequest request)
        {
            var id = IdentityProvider().FromRequestId(request.id);
            return new getExtendedMetadataResponse(PhysicalResource.FromId(id).ToMediaMetadata());
        }

        public override getMediaMetadataResponse GetMediaMetadata(getMediaMetadataRequest request)
        {
            var id = IdentityProvider().FromRequestId(request.id);
            return new getMediaMetadataResponse(PhysicalResource.FromId(id).ToMediaMetadata());
        }

        public override getMediaURIResponse GetMediaUri(getMediaURIRequest request)
        {
            var id = IdentityProvider().FromRequestId(request.id);
            return new getMediaURIResponse(MusicRepository().BuildUriForId(id));
        }

        public override getLastUpdateResponse GetLastUpdate(getLastUpdateRequest request)
        {
            return getLastUpdateResponse.ChangedRightNow();
        }

        public override searchResponse Search(searchRequest request)
        {
            var results = MusicRepository().Search(request.term);
            return new searchResponse(results.DirectoryToSonosResponse(request.index, request.count));
        }
    }
}