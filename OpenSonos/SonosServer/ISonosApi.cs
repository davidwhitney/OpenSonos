using System.ServiceModel;

namespace OpenSonos.SonosServer
{
    [ServiceContract(Namespace = "http://www.sonos.com/Services/1.1", ConfigurationName = "SonosContract.ISonosApi")]
    public interface ISonosApi
    {
        [OperationContract(Action = "http://www.sonos.com/Services/1.1#getSessionId", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#getSessionId", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        getSessionIdResponse GetSessionId(getSessionIdRequest request);

        [OperationContract(Action = "http://www.sonos.com/Services/1.1#getMetadata", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#getMetadata", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        getMetadataResponse GetMetadata(getMetadataRequest request);

        [OperationContract(Action = "http://www.sonos.com/Services/1.1#getExtendedMetadata", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#getExtendedMetadata", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        getExtendedMetadataResponse GetExtendedMetadata(getExtendedMetadataRequest request);

        [OperationContract(Action = "http://www.sonos.com/Services/1.1#getExtendedMetadataText", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#getExtendedMetadataText", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        getExtendedMetadataTextResponse GetExtendedMetadataText(getExtendedMetadataTextRequest request);

        [OperationContract(Action = "http://www.sonos.com/Services/1.1#rateItem", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#rateItem", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        rateItemResponse RateItem(rateItemRequest request);

        [OperationContract(Action = "http://www.sonos.com/Services/1.1#search", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#search", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        searchResponse Search(searchRequest request);

        [OperationContract(Action = "http://www.sonos.com/Services/1.1#getMediaMetadata", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#getMediaMetadata", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        getMediaMetadataResponse GetMediaMetadata(getMediaMetadataRequest request);

        [OperationContract(Action = "http://www.sonos.com/Services/1.1#getMediaURI", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#getMediaURI", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        getMediaURIResponse GetMediaUri(getMediaURIRequest request);

        [OperationContract(Action = "http://www.sonos.com/Services/1.1#createItem", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#createItem", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        createItemResponse CreateItem(createItemRequest request);

        [OperationContract(Action = "http://www.sonos.com/Services/1.1#deleteItem", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#deleteItem", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        deleteItemResponse DeleteItem(deleteItemRequest request);

        [OperationContract(Action = "http://www.sonos.com/Services/1.1#getScrollIndices", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#getScrollIndices", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        getScrollIndicesResponse GetScrollIndices(getScrollIndicesRequest request);

        [OperationContract(Action = "http://www.sonos.com/Services/1.1#getLastUpdate", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#getLastUpdate", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        getLastUpdateResponse GetLastUpdate(getLastUpdateRequest request);

        [OperationContract(Action = "http://www.sonos.com/Services/1.1#reportStatus", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#reportStatus", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        reportStatusResponse ReportStatus(reportStatusRequest request);

        [OperationContract(Action = "http://www.sonos.com/Services/1.1#setPlayedSeconds", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#setPlayedSeconds", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        setPlayedSecondsResponse SetPlayedSeconds(setPlayedSecondsRequest request);

        [OperationContract(Action = "http://www.sonos.com/Services/1.1#reportPlaySeconds", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#reportPlaySeconds", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        reportPlaySecondsResponse ReportPlaySeconds(reportPlaySecondsRequest request);

        [OperationContract(Action = "http://www.sonos.com/Services/1.1#reportPlayStatus", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#reportPlayStatus", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        reportPlayStatusResponse ReportPlayStatus(reportPlayStatusRequest request);

        [OperationContract(Action = "http://www.sonos.com/Services/1.1#reportAccountAction", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#reportAccountAction", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        reportAccountActionResponse ReportAccountAction(reportAccountActionRequest request);

        [OperationContract(Action = "http://www.sonos.com/Services/1.1#getDeviceLinkCode", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#getDeviceLinkCode", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        getDeviceLinkCodeResponse GetDeviceLinkCode(getDeviceLinkCodeRequest request);

        [OperationContract(Action = "http://www.sonos.com/Services/1.1#getDeviceAuthToken", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#getDeviceAuthToken", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        getDeviceAuthTokenResponse GetDeviceAuthToken(getDeviceAuthTokenRequest request);

        [OperationContract(Action = "http://www.sonos.com/Services/1.1#getStreamingMetadata", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#getStreamingMetadata", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        getStreamingMetadataResponse GetStreamingMetadata(getStreamingMetadataRequest request);

        [OperationContract(Action = "http://www.sonos.com/Services/1.1#getContentKey", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#getContentKey", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        getContentKeyResponse GetContentKey(getContentKeyRequest request);

        [OperationContract(Action = "http://www.sonos.com/Services/1.1#createContainer", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#createContainer", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        createContainerResponse CreateContainer(createContainerRequest request);

        [OperationContract(Action = "http://www.sonos.com/Services/1.1#addToContainer", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#addToContainer", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        addToContainerResponse AddToContainer(addToContainerRequest request);

        [OperationContract(Action = "http://www.sonos.com/Services/1.1#renameContainer", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#renameContainer", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        renameContainerResponse RenameContainer(renameContainerRequest request);

        [OperationContract(Action = "http://www.sonos.com/Services/1.1#deleteContainer", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#deleteContainer", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        deleteContainerResponse DeleteContainer(deleteContainerRequest request);

        [OperationContract(Action = "http://www.sonos.com/Services/1.1#removeFromContainer", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#removeFromContainer", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        removeFromContainerResponse RemoveFromContainer(removeFromContainerRequest request);

        [OperationContract(Action = "http://www.sonos.com/Services/1.1#reorderContainer", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#reorderContainer", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        reorderContainerResponse ReorderContainer(reorderContainerRequest request);
    }
}