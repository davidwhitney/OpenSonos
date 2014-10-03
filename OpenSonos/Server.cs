using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading.Tasks;
using OpenSonos.SonosServer;

namespace OpenSonos
{
    public static class Server
    {
        public static ServerCreationStateWrapper ImplementedBy<TServerType>()
        {
            return new ServerCreationStateWrapper(typeof(TServerType));
        }

        public async static Task<List<SonosPlayer>> DiscoverPlayers()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            var serverIp = host.AddressList.First(x => x.AddressFamily == AddressFamily.InterNetwork);
            var subnet = string.Join(".", serverIp.ToString().Split('.').Take(3));

            var sonosPlayers = new List<SonosPlayer>();

            var http = new HttpClient();
            for (var ipPart = 1; ipPart < 256; ipPart++)
            {
                var ip = subnet + "." + ipPart;
                var response = await http.GetAsync(string.Format("http://{0}:1400/customsd.htm", ip));
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    sonosPlayers.Add(new SonosPlayer(ip));
                }
            }

            return sonosPlayers;
        }
    }

    public class SonosPlayer
    {
        public IPAddress Address { get; set; }

        public SonosPlayer(string address)
        {
            Address = IPAddress.Parse(address);
        }
    }

    public class ServerCreationStateWrapper
    {
        private readonly Type _unconfiguredHostType;

        public ServerCreationStateWrapper(Type unconfiguredHostType)
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
