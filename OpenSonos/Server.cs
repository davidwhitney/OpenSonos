using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using OpenSonos.SonosServer;

namespace OpenSonos
{
    public static class Server
    {
        public static ServerCreationStateWrapper ImplementedBy<TServerType>()
        {
            return new ServerCreationStateWrapper(typeof(TServerType));
        }
    }

    public class ServerCreationStateWrapper
    {
        private readonly Type _unconfiguredHostType;

        public ServerCreationStateWrapper(Type unconfiguredHostType)
        {
            _unconfiguredHostType = unconfiguredHostType;
        }

        public ServiceHost HostedAt(Uri baseUri, string path)
        {
            var host = new ServiceHost(_unconfiguredHostType, baseUri);
            host.Description.Behaviors.Add(new ServiceMetadataBehavior { MetadataExporter = { PolicyVersion = PolicyVersion.Policy15 } });
            host.AddServiceEndpoint(typeof(ISonosApi), new BasicHttpBinding(), path);
            host.AddServiceEndpoint(typeof(ISonosApi), new WSHttpBinding(), "");

            var endpoint = host.AddServiceEndpoint(typeof(ISonosMetadataApi), new BasicHttpBinding(), "metadata");
            endpoint.Binding = new WebHttpBinding();
            endpoint.Behaviors.Add(new WebHttpBehavior());

            host.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexHttpBinding(), "mex");
            return host;
        }
    }
}
