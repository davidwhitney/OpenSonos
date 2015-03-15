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
		private static SmapiSoapControllerDependencies _ { get { return Dependencies(); } }

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

	        var results = _.MusicRepository
						   .GetResources(request.id)
						   .ToMediaList(request.index, request.count);

	        var dto = new getMetadataResponse(results);

			timer.Stop();
			Console.WriteLine(timer.Elapsed.TotalMilliseconds + "ms");
	        return dto;
        }

        public override getExtendedMetadataResponse GetExtendedMetadata(getExtendedMetadataRequest request)
        {
            var id = _.IdentityProvider.FromRequestId(request.id);
            return new getExtendedMetadataResponse(PhysicalResource.FromId(id).ToMediaMetadata());
        }

        public override getMediaMetadataResponse GetMediaMetadata(getMediaMetadataRequest request)
        {
            var id = _.IdentityProvider.FromRequestId(request.id);
            return new getMediaMetadataResponse(PhysicalResource.FromId(id).ToMediaMetadata());
        }

        public override getMediaURIResponse GetMediaUri(getMediaURIRequest request)
        {
            var id = _.IdentityProvider.FromRequestId(request.id);
            return new getMediaURIResponse(id.Uri);
        }

        public override getLastUpdateResponse GetLastUpdate(getLastUpdateRequest request)
        {
            return getLastUpdateResponse.ChangedAt(_.MusicRepository.LastUpdate);
        }

        public override searchResponse Search(searchRequest request)
        {
            var results = _.MusicRepository.Search(request.term);
            return new searchResponse(results.ToMediaList(request.index, request.count));
        }
    }
}