using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace OpenSonos.SonosServer
{
    [ServiceContract]
    [XmlSerializerFormat]
    public interface ISonosMetadataApi
    {
        [OperationContract]
        [WebGet(UriTemplate = "presentation-maps", BodyStyle = WebMessageBodyStyle.Bare)]
        [ServiceKnownType(typeof(PresentationMap))]
        PresentationMap GetPresentationMaps();
    }
}
