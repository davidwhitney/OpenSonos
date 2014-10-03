using System.ServiceModel;

namespace OpenSonos.SonosContract
{
    [ServiceContract(Namespace = "http://www.sonos.com/Services/1.1", ConfigurationName = "SonosContract.ISonosApi")]
    public interface ISonosApi
    {
        // CODEGEN: Generating message contract since message getSessionIdRequest has headers
        [OperationContract(Action = "http://www.sonos.com/Services/1.1#getSessionId", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#getSessionId", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        getSessionIdResponse getSessionId(getSessionIdRequest request);

        // CODEGEN: Generating message contract since message getMetadataRequest has headers
        [OperationContract(Action = "http://www.sonos.com/Services/1.1#getMetadata", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#getMetadata", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        getMetadataResponse getMetadata(getMetadataRequest request);

        // CODEGEN: Generating message contract since message getExtendedMetadataRequest has headers
        [OperationContract(Action = "http://www.sonos.com/Services/1.1#getExtendedMetadata", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#getExtendedMetadata", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        getExtendedMetadataResponse getExtendedMetadata(getExtendedMetadataRequest request);

        // CODEGEN: Generating message contract since message getExtendedMetadataTextRequest has headers
        [OperationContract(Action = "http://www.sonos.com/Services/1.1#getExtendedMetadataText", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#getExtendedMetadataText", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        getExtendedMetadataTextResponse getExtendedMetadataText(getExtendedMetadataTextRequest request);

        // CODEGEN: Generating message contract since message rateItemRequest has headers
        [OperationContract(Action = "http://www.sonos.com/Services/1.1#rateItem", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#rateItem", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        rateItemResponse rateItem(rateItemRequest request);

        // CODEGEN: Generating message contract since message searchRequest has headers
        [OperationContract(Action = "http://www.sonos.com/Services/1.1#search", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#search", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        searchResponse search(searchRequest request);

        // CODEGEN: Generating message contract since message getMediaMetadataRequest has headers
        [OperationContract(Action = "http://www.sonos.com/Services/1.1#getMediaMetadata", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#getMediaMetadata", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        getMediaMetadataResponse getMediaMetadata(getMediaMetadataRequest request);

        // CODEGEN: Generating message contract since message getMediaURIRequest has headers
        [OperationContract(Action = "http://www.sonos.com/Services/1.1#getMediaURI", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#getMediaURI", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        getMediaURIResponse getMediaURI(getMediaURIRequest request);

        // CODEGEN: Generating message contract since message createItemRequest has headers
        [OperationContract(Action = "http://www.sonos.com/Services/1.1#createItem", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#createItem", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        createItemResponse createItem(createItemRequest request);

        // CODEGEN: Generating message contract since message deleteItemRequest has headers
        [OperationContract(Action = "http://www.sonos.com/Services/1.1#deleteItem", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#deleteItem", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        deleteItemResponse deleteItem(deleteItemRequest request);

        // CODEGEN: Generating message contract since message getScrollIndicesRequest has headers
        [OperationContract(Action = "http://www.sonos.com/Services/1.1#getScrollIndices", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#getScrollIndices", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        getScrollIndicesResponse getScrollIndices(getScrollIndicesRequest request);

        // CODEGEN: Generating message contract since message getLastUpdateRequest has headers
        [OperationContract(Action = "http://www.sonos.com/Services/1.1#getLastUpdate", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#getLastUpdate", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        getLastUpdateResponse getLastUpdate(getLastUpdateRequest request);

        // CODEGEN: Generating message contract since message reportStatusRequest has headers
        [OperationContract(Action = "http://www.sonos.com/Services/1.1#reportStatus", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#reportStatus", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        reportStatusResponse reportStatus(reportStatusRequest request);

        // CODEGEN: Generating message contract since message setPlayedSecondsRequest has headers
        [OperationContract(Action = "http://www.sonos.com/Services/1.1#setPlayedSeconds", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#setPlayedSeconds", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        setPlayedSecondsResponse setPlayedSeconds(setPlayedSecondsRequest request);

        // CODEGEN: Generating message contract since message reportPlaySecondsRequest has headers
        [OperationContract(Action = "http://www.sonos.com/Services/1.1#reportPlaySeconds", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#reportPlaySeconds", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        reportPlaySecondsResponse reportPlaySeconds(reportPlaySecondsRequest request);

        // CODEGEN: Generating message contract since message reportPlayStatusRequest has headers
        [OperationContract(Action = "http://www.sonos.com/Services/1.1#reportPlayStatus", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#reportPlayStatus", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        reportPlayStatusResponse reportPlayStatus(reportPlayStatusRequest request);

        // CODEGEN: Generating message contract since message reportAccountActionRequest has headers
        [OperationContract(Action = "http://www.sonos.com/Services/1.1#reportAccountAction", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#reportAccountAction", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        reportAccountActionResponse reportAccountAction(reportAccountActionRequest request);

        // CODEGEN: Generating message contract since message getDeviceLinkCodeRequest has headers
        [OperationContract(Action = "http://www.sonos.com/Services/1.1#getDeviceLinkCode", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#getDeviceLinkCode", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        getDeviceLinkCodeResponse getDeviceLinkCode(getDeviceLinkCodeRequest request);

        // CODEGEN: Generating message contract since message getDeviceAuthTokenRequest has headers
        [OperationContract(Action = "http://www.sonos.com/Services/1.1#getDeviceAuthToken", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#getDeviceAuthToken", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        getDeviceAuthTokenResponse getDeviceAuthToken(getDeviceAuthTokenRequest request);

        // CODEGEN: Generating message contract since message getStreamingMetadataRequest has headers
        [OperationContract(Action = "http://www.sonos.com/Services/1.1#getStreamingMetadata", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#getStreamingMetadata", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        getStreamingMetadataResponse getStreamingMetadata(getStreamingMetadataRequest request);

        // CODEGEN: Generating message contract since message getContentKeyRequest has headers
        [OperationContract(Action = "http://www.sonos.com/Services/1.1#getContentKey", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#getContentKey", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        getContentKeyResponse getContentKey(getContentKeyRequest request);

        // CODEGEN: Generating message contract since message createContainerRequest has headers
        [OperationContract(Action = "http://www.sonos.com/Services/1.1#createContainer", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#createContainer", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        createContainerResponse createContainer(createContainerRequest request);

        // CODEGEN: Generating message contract since message addToContainerRequest has headers
        [OperationContract(Action = "http://www.sonos.com/Services/1.1#addToContainer", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#addToContainer", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        addToContainerResponse addToContainer(addToContainerRequest request);

        // CODEGEN: Generating message contract since message renameContainerRequest has headers
        [OperationContract(Action = "http://www.sonos.com/Services/1.1#renameContainer", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#renameContainer", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        renameContainerResponse renameContainer(renameContainerRequest request);

        // CODEGEN: Generating message contract since message deleteContainerRequest has headers
        [OperationContract(Action = "http://www.sonos.com/Services/1.1#deleteContainer", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#deleteContainer", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        deleteContainerResponse deleteContainer(deleteContainerRequest request);

        // CODEGEN: Generating message contract since message removeFromContainerRequest has headers
        [OperationContract(Action = "http://www.sonos.com/Services/1.1#removeFromContainer", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#removeFromContainer", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        removeFromContainerResponse removeFromContainer(removeFromContainerRequest request);

        // CODEGEN: Generating message contract since message reorderContainerRequest has headers
        [OperationContract(Action = "http://www.sonos.com/Services/1.1#reorderContainer", ReplyAction = "*")]
        [FaultContract(typeof (int), Action = "http://www.sonos.com/Services/1.1#reorderContainer", Name = "SonosError")]
        [XmlSerializerFormat(SupportFaults = true)]
        [ServiceKnownType(typeof (AbstractMedia))]
        reorderContainerResponse reorderContainer(reorderContainerRequest request);
    }
}