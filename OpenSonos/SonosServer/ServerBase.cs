using System;
using System.ServiceModel;
using OpenSonos.SonosServer.Metadata;

namespace OpenSonos.SonosServer
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public abstract class ServerBase : ISonosApi, ISonosMetadataApi
    {
        public virtual Presentation GetPresentationMaps()
        {
            throw new NotImplementedException();
        }

        // Bare minimum implementation
        public abstract getSessionIdResponse GetSessionId(getSessionIdRequest request);
        public abstract getMetadataResponse GetMetadata(getMetadataRequest request);
        public abstract getExtendedMetadataResponse GetExtendedMetadata(getExtendedMetadataRequest request);
        public abstract getMediaMetadataResponse GetMediaMetadata(getMediaMetadataRequest request);
        public abstract getMediaURIResponse GetMediaUri(getMediaURIRequest request);

        public virtual getExtendedMetadataTextResponse GetExtendedMetadataText(getExtendedMetadataTextRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual rateItemResponse RateItem(rateItemRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual searchResponse Search(searchRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual createItemResponse CreateItem(createItemRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual deleteItemResponse DeleteItem(deleteItemRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual getScrollIndicesResponse GetScrollIndices(getScrollIndicesRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual getLastUpdateResponse GetLastUpdate(getLastUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual reportStatusResponse ReportStatus(reportStatusRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual setPlayedSecondsResponse SetPlayedSeconds(setPlayedSecondsRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual reportPlaySecondsResponse ReportPlaySeconds(reportPlaySecondsRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual reportPlayStatusResponse ReportPlayStatus(reportPlayStatusRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual reportAccountActionResponse ReportAccountAction(reportAccountActionRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual getDeviceLinkCodeResponse GetDeviceLinkCode(getDeviceLinkCodeRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual getDeviceAuthTokenResponse GetDeviceAuthToken(getDeviceAuthTokenRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual getStreamingMetadataResponse GetStreamingMetadata(getStreamingMetadataRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual getContentKeyResponse GetContentKey(getContentKeyRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual createContainerResponse CreateContainer(createContainerRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual addToContainerResponse AddToContainer(addToContainerRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual renameContainerResponse RenameContainer(renameContainerRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual deleteContainerResponse DeleteContainer(deleteContainerRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual removeFromContainerResponse RemoveFromContainer(removeFromContainerRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual reorderContainerResponse ReorderContainer(reorderContainerRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
