using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using OpenSonos.SonosServer;

namespace OpenSonos
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(Server), new Uri("http://localhost:8000"));
            host.Description.Behaviors.Add(new ServiceMetadataBehavior {MetadataExporter = {PolicyVersion = PolicyVersion.Policy15}});
            host.AddServiceEndpoint(typeof(SonosContract.SonosSoap), new BasicHttpBinding(), "Soap");
            host.AddServiceEndpoint(typeof(SonosContract.SonosSoap), new WSHttpBinding(), "");
            host.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

            host.Open();

            Console.WriteLine("Hosting");


            Console.ReadLine();
        }
    }
}
