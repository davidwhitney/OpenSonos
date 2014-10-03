using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using OpenSonos.SonosServer;

namespace OpenSonos.LocalMusicServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var uri = new Uri("http://localhost:8000");
            const string path = "sonos-api";

            var host = new ServiceHost(typeof(ServerBase), uri);
            host.Description.Behaviors.Add(new ServiceMetadataBehavior {MetadataExporter = {PolicyVersion = PolicyVersion.Policy15}});
            host.AddServiceEndpoint(typeof(ISonosApi), new BasicHttpBinding(), path);
            host.AddServiceEndpoint(typeof(ISonosApi), new WSHttpBinding(), "");
            host.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

            host.Open();

            Console.WriteLine("Hosting Sonos API at {0}{1}", uri, path);


            Console.ReadLine();
        }
    }
}
