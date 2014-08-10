namespace OpenSonos.SonosContract
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.sonos.com/Services/1.1", ConfigurationName="SonosContract.SonosSoap")]
    public interface SonosSoap {
        
        // CODEGEN: Generating message contract since message getSessionIdRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://www.sonos.com/Services/1.1#getSessionId", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(int), Action="http://www.sonos.com/Services/1.1#getSessionId", Name="SonosError")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AbstractMedia))]
        OpenSonos.SonosContract.getSessionIdResponse getSessionId(OpenSonos.SonosContract.getSessionIdRequest request);
        
        // CODEGEN: Generating message contract since message getMetadataRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://www.sonos.com/Services/1.1#getMetadata", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(int), Action="http://www.sonos.com/Services/1.1#getMetadata", Name="SonosError")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AbstractMedia))]
        OpenSonos.SonosContract.getMetadataResponse getMetadata(OpenSonos.SonosContract.getMetadataRequest request);
        
        // CODEGEN: Generating message contract since message getExtendedMetadataRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://www.sonos.com/Services/1.1#getExtendedMetadata", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(int), Action="http://www.sonos.com/Services/1.1#getExtendedMetadata", Name="SonosError")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AbstractMedia))]
        OpenSonos.SonosContract.getExtendedMetadataResponse getExtendedMetadata(OpenSonos.SonosContract.getExtendedMetadataRequest request);
        
        // CODEGEN: Generating message contract since message getExtendedMetadataTextRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://www.sonos.com/Services/1.1#getExtendedMetadataText", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(int), Action="http://www.sonos.com/Services/1.1#getExtendedMetadataText", Name="SonosError")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AbstractMedia))]
        OpenSonos.SonosContract.getExtendedMetadataTextResponse getExtendedMetadataText(OpenSonos.SonosContract.getExtendedMetadataTextRequest request);
        
        // CODEGEN: Generating message contract since message rateItemRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://www.sonos.com/Services/1.1#rateItem", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(int), Action="http://www.sonos.com/Services/1.1#rateItem", Name="SonosError")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AbstractMedia))]
        OpenSonos.SonosContract.rateItemResponse rateItem(OpenSonos.SonosContract.rateItemRequest request);
        
        // CODEGEN: Generating message contract since message searchRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://www.sonos.com/Services/1.1#search", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(int), Action="http://www.sonos.com/Services/1.1#search", Name="SonosError")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AbstractMedia))]
        OpenSonos.SonosContract.searchResponse search(OpenSonos.SonosContract.searchRequest request);
        
        // CODEGEN: Generating message contract since message getMediaMetadataRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://www.sonos.com/Services/1.1#getMediaMetadata", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(int), Action="http://www.sonos.com/Services/1.1#getMediaMetadata", Name="SonosError")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AbstractMedia))]
        OpenSonos.SonosContract.getMediaMetadataResponse getMediaMetadata(OpenSonos.SonosContract.getMediaMetadataRequest request);
        
        // CODEGEN: Generating message contract since message getMediaURIRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://www.sonos.com/Services/1.1#getMediaURI", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(int), Action="http://www.sonos.com/Services/1.1#getMediaURI", Name="SonosError")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AbstractMedia))]
        OpenSonos.SonosContract.getMediaURIResponse getMediaURI(OpenSonos.SonosContract.getMediaURIRequest request);
        
        // CODEGEN: Generating message contract since message createItemRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://www.sonos.com/Services/1.1#createItem", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(int), Action="http://www.sonos.com/Services/1.1#createItem", Name="SonosError")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AbstractMedia))]
        OpenSonos.SonosContract.createItemResponse createItem(OpenSonos.SonosContract.createItemRequest request);
        
        // CODEGEN: Generating message contract since message deleteItemRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://www.sonos.com/Services/1.1#deleteItem", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(int), Action="http://www.sonos.com/Services/1.1#deleteItem", Name="SonosError")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AbstractMedia))]
        OpenSonos.SonosContract.deleteItemResponse deleteItem(OpenSonos.SonosContract.deleteItemRequest request);
        
        // CODEGEN: Generating message contract since message getScrollIndicesRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://www.sonos.com/Services/1.1#getScrollIndices", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(int), Action="http://www.sonos.com/Services/1.1#getScrollIndices", Name="SonosError")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AbstractMedia))]
        OpenSonos.SonosContract.getScrollIndicesResponse getScrollIndices(OpenSonos.SonosContract.getScrollIndicesRequest request);
        
        // CODEGEN: Generating message contract since message getLastUpdateRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://www.sonos.com/Services/1.1#getLastUpdate", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(int), Action="http://www.sonos.com/Services/1.1#getLastUpdate", Name="SonosError")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AbstractMedia))]
        OpenSonos.SonosContract.getLastUpdateResponse getLastUpdate(OpenSonos.SonosContract.getLastUpdateRequest request);
        
        // CODEGEN: Generating message contract since message reportStatusRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://www.sonos.com/Services/1.1#reportStatus", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(int), Action="http://www.sonos.com/Services/1.1#reportStatus", Name="SonosError")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AbstractMedia))]
        OpenSonos.SonosContract.reportStatusResponse reportStatus(OpenSonos.SonosContract.reportStatusRequest request);
        
        // CODEGEN: Generating message contract since message setPlayedSecondsRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://www.sonos.com/Services/1.1#setPlayedSeconds", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(int), Action="http://www.sonos.com/Services/1.1#setPlayedSeconds", Name="SonosError")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AbstractMedia))]
        OpenSonos.SonosContract.setPlayedSecondsResponse setPlayedSeconds(OpenSonos.SonosContract.setPlayedSecondsRequest request);
        
        // CODEGEN: Generating message contract since message reportPlaySecondsRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://www.sonos.com/Services/1.1#reportPlaySeconds", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(int), Action="http://www.sonos.com/Services/1.1#reportPlaySeconds", Name="SonosError")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AbstractMedia))]
        OpenSonos.SonosContract.reportPlaySecondsResponse reportPlaySeconds(OpenSonos.SonosContract.reportPlaySecondsRequest request);
        
        // CODEGEN: Generating message contract since message reportPlayStatusRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://www.sonos.com/Services/1.1#reportPlayStatus", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(int), Action="http://www.sonos.com/Services/1.1#reportPlayStatus", Name="SonosError")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AbstractMedia))]
        OpenSonos.SonosContract.reportPlayStatusResponse reportPlayStatus(OpenSonos.SonosContract.reportPlayStatusRequest request);
        
        // CODEGEN: Generating message contract since message reportAccountActionRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://www.sonos.com/Services/1.1#reportAccountAction", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(int), Action="http://www.sonos.com/Services/1.1#reportAccountAction", Name="SonosError")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AbstractMedia))]
        OpenSonos.SonosContract.reportAccountActionResponse reportAccountAction(OpenSonos.SonosContract.reportAccountActionRequest request);
        
        // CODEGEN: Generating message contract since message getDeviceLinkCodeRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://www.sonos.com/Services/1.1#getDeviceLinkCode", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(int), Action="http://www.sonos.com/Services/1.1#getDeviceLinkCode", Name="SonosError")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AbstractMedia))]
        OpenSonos.SonosContract.getDeviceLinkCodeResponse getDeviceLinkCode(OpenSonos.SonosContract.getDeviceLinkCodeRequest request);
        
        // CODEGEN: Generating message contract since message getDeviceAuthTokenRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://www.sonos.com/Services/1.1#getDeviceAuthToken", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(int), Action="http://www.sonos.com/Services/1.1#getDeviceAuthToken", Name="SonosError")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AbstractMedia))]
        OpenSonos.SonosContract.getDeviceAuthTokenResponse getDeviceAuthToken(OpenSonos.SonosContract.getDeviceAuthTokenRequest request);
        
        // CODEGEN: Generating message contract since message getStreamingMetadataRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://www.sonos.com/Services/1.1#getStreamingMetadata", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(int), Action="http://www.sonos.com/Services/1.1#getStreamingMetadata", Name="SonosError")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AbstractMedia))]
        OpenSonos.SonosContract.getStreamingMetadataResponse getStreamingMetadata(OpenSonos.SonosContract.getStreamingMetadataRequest request);
        
        // CODEGEN: Generating message contract since message getContentKeyRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://www.sonos.com/Services/1.1#getContentKey", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(int), Action="http://www.sonos.com/Services/1.1#getContentKey", Name="SonosError")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AbstractMedia))]
        OpenSonos.SonosContract.getContentKeyResponse getContentKey(OpenSonos.SonosContract.getContentKeyRequest request);
        
        // CODEGEN: Generating message contract since message createContainerRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://www.sonos.com/Services/1.1#createContainer", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(int), Action="http://www.sonos.com/Services/1.1#createContainer", Name="SonosError")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AbstractMedia))]
        OpenSonos.SonosContract.createContainerResponse createContainer(OpenSonos.SonosContract.createContainerRequest request);
        
        // CODEGEN: Generating message contract since message addToContainerRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://www.sonos.com/Services/1.1#addToContainer", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(int), Action="http://www.sonos.com/Services/1.1#addToContainer", Name="SonosError")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AbstractMedia))]
        OpenSonos.SonosContract.addToContainerResponse addToContainer(OpenSonos.SonosContract.addToContainerRequest request);
        
        // CODEGEN: Generating message contract since message renameContainerRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://www.sonos.com/Services/1.1#renameContainer", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(int), Action="http://www.sonos.com/Services/1.1#renameContainer", Name="SonosError")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AbstractMedia))]
        OpenSonos.SonosContract.renameContainerResponse renameContainer(OpenSonos.SonosContract.renameContainerRequest request);
        
        // CODEGEN: Generating message contract since message deleteContainerRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://www.sonos.com/Services/1.1#deleteContainer", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(int), Action="http://www.sonos.com/Services/1.1#deleteContainer", Name="SonosError")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AbstractMedia))]
        OpenSonos.SonosContract.deleteContainerResponse deleteContainer(OpenSonos.SonosContract.deleteContainerRequest request);
        
        // CODEGEN: Generating message contract since message removeFromContainerRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://www.sonos.com/Services/1.1#removeFromContainer", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(int), Action="http://www.sonos.com/Services/1.1#removeFromContainer", Name="SonosError")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AbstractMedia))]
        OpenSonos.SonosContract.removeFromContainerResponse removeFromContainer(OpenSonos.SonosContract.removeFromContainerRequest request);
        
        // CODEGEN: Generating message contract since message reorderContainerRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://www.sonos.com/Services/1.1#reorderContainer", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(int), Action="http://www.sonos.com/Services/1.1#reorderContainer", Name="SonosError")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AbstractMedia))]
        OpenSonos.SonosContract.reorderContainerResponse reorderContainer(OpenSonos.SonosContract.reorderContainerRequest request);
    }
}