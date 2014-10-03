using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using OpenSonos.SonosServer;

namespace OpenSonos
{
    class Program
    {
        static void Main(string[] args)
        {
            var uri = new Uri("http://localhost:8000");
            const string path = "sonos-api";

            var host = new ServiceHost(typeof(Server), uri);
            host.Description.Behaviors.Add(new ServiceMetadataBehavior {MetadataExporter = {PolicyVersion = PolicyVersion.Policy15}});
            host.AddServiceEndpoint(typeof(SonosContract.ISonosApi), new BasicHttpBinding(), path);
            host.AddServiceEndpoint(typeof(SonosContract.ISonosApi), new WSHttpBinding(), "");
            host.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

            host.Open();

            Console.WriteLine("Hosting Sonos API at {0}{1}", uri, path);


            Console.ReadLine();
        }
    }
}
