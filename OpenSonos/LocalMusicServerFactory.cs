using System;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using OpenSonos.SonosServer;

namespace OpenSonos
{
    public class LocalMusicServerFactory
    {
        private readonly Type _unconfiguredHostType;

        public LocalMusicServerFactory(Type unconfiguredHostType)
        {
            _unconfiguredHostType = unconfiguredHostType;
        }

        public ServiceHost HostedAt(Uri baseUri)
        {
            var host = new ServiceHost(_unconfiguredHostType, baseUri);
            host.Description.Behaviors.Add(new ServiceMetadataBehavior { MetadataExporter = { PolicyVersion = PolicyVersion.Policy15 } });
            host.AddServiceEndpoint(typeof(ISonosApi), new BasicHttpBinding(), "sonos-api");
            host.AddServiceEndpoint(typeof(ISonosApi), new WSHttpBinding(), "");

            var endpoint = host.AddServiceEndpoint(typeof(ISonosMetadataApi), new BasicHttpBinding(), "metadata");
            endpoint.Binding = new WebHttpBinding();
            endpoint.Behaviors.Add(new WebHttpBehavior());

            host.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

            Console.WriteLine("Hosting Sonos API endpoints:" + Environment.NewLine);
            foreach (var ep in host.Description.Endpoints.OrderBy(x=>x.Address.Uri.ToString().Length))
            {
                Console.WriteLine("\t" + ep.Address);
            }
            
            return host;
        }
    }
}