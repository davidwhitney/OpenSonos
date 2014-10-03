using System;
using System.ServiceModel;

namespace OpenSonos.SonosServer
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class ServerBase : ISonosApi, ISonosMetadataApi
    {
        public virtual PresentationMap GetPresentationMaps()
        {
            throw new NotImplementedException();
        }

        public virtual getSessionIdResponse getSessionId(getSessionIdRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual getMetadataResponse getMetadata(getMetadataRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual getExtendedMetadataResponse getExtendedMetadata(getExtendedMetadataRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual getExtendedMetadataTextResponse getExtendedMetadataText(getExtendedMetadataTextRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual rateItemResponse rateItem(rateItemRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual searchResponse search(searchRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual getMediaMetadataResponse getMediaMetadata(getMediaMetadataRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual getMediaURIResponse getMediaURI(getMediaURIRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual createItemResponse createItem(createItemRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual deleteItemResponse deleteItem(deleteItemRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual getScrollIndicesResponse getScrollIndices(getScrollIndicesRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual getLastUpdateResponse getLastUpdate(getLastUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual reportStatusResponse reportStatus(reportStatusRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual setPlayedSecondsResponse setPlayedSeconds(setPlayedSecondsRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual reportPlaySecondsResponse reportPlaySeconds(reportPlaySecondsRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual reportPlayStatusResponse reportPlayStatus(reportPlayStatusRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual reportAccountActionResponse reportAccountAction(reportAccountActionRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual getDeviceLinkCodeResponse getDeviceLinkCode(getDeviceLinkCodeRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual getDeviceAuthTokenResponse getDeviceAuthToken(getDeviceAuthTokenRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual getStreamingMetadataResponse getStreamingMetadata(getStreamingMetadataRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual getContentKeyResponse getContentKey(getContentKeyRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual createContainerResponse createContainer(createContainerRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual addToContainerResponse addToContainer(addToContainerRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual renameContainerResponse renameContainer(renameContainerRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual deleteContainerResponse deleteContainer(deleteContainerRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual removeFromContainerResponse removeFromContainer(removeFromContainerRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual reorderContainerResponse reorderContainer(reorderContainerRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
