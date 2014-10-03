using System.ServiceModel;
using System.ServiceModel.Web;
using OpenSonos.SonosServer.Metadata;

namespace OpenSonos.SonosServer
{
    [ServiceContract]
    [XmlSerializerFormat]
    public interface ISonosMetadataApi
    {
        [OperationContract]
        [WebGet(UriTemplate = "presentation-maps", BodyStyle = WebMessageBodyStyle.Bare)]
        [ServiceKnownType(typeof(PresentationMap))]
        Presentation GetPresentationMaps();
    }
}
