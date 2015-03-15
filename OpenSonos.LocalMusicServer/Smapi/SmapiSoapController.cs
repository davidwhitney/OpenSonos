using System;
using System.Diagnostics;
using OpenSonos.LocalMusicServer.Browsing;
using OpenSonos.SonosServer;
using OpenSonos.SonosServer.Metadata;

namespace OpenSonos.LocalMusicServer.Smapi
{
    public class SmapiSoapController : ServerBase
    {
        public static Func<SmapiSoapControllerDependencies> Dependencies { get; set; }
        private readonly SmapiSoapControllerDependencies _deps;

        public SmapiSoapController()
        {
            _deps = Dependencies();
        }

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
	        var timer = Stopwatch.StartNew();

			var results = _deps.MusicRepository.GetResources(request.id);
	        var dto = new getMetadataResponse(results.DirectoryToSonosResponse(request.index, request.count));

			timer.Stop();
			Console.WriteLine(timer.Elapsed.TotalMilliseconds + "ms");
	        return dto;
        }

        public override getExtendedMetadataResponse GetExtendedMetadata(getExtendedMetadataRequest request)
        {
            var id = _deps.IdentityProvider.FromRequestId(request.id);
            return new getExtendedMetadataResponse(PhysicalResource.FromId(id).ToMediaMetadata());
        }

        public override getMediaMetadataResponse GetMediaMetadata(getMediaMetadataRequest request)
        {
            var id = _deps.IdentityProvider.FromRequestId(request.id);
            return new getMediaMetadataResponse(PhysicalResource.FromId(id).ToMediaMetadata());
        }

        public override getMediaURIResponse GetMediaUri(getMediaURIRequest request)
        {
            var id = _deps.IdentityProvider.FromRequestId(request.id);
            return new getMediaURIResponse(id.Uri);
        }

        public override getLastUpdateResponse GetLastUpdate(getLastUpdateRequest request)
        {
            return getLastUpdateResponse.ChangedAt(_deps.MusicRepository.LastUpdate);
        }

        public override searchResponse Search(searchRequest request)
        {
            var results = _deps.MusicRepository.Search(request.term);
            return new searchResponse(results.DirectoryToSonosResponse(request.index, request.count));
        }
    }
}