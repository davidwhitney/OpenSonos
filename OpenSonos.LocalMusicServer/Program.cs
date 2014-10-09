using System;
using System.ComponentModel;
using System.Linq;
using System.ServiceProcess;
using Ninject;
using OpenSonos.LocalMusicServer.Bootstrapping;
using SimpleServices;

namespace OpenSonos.LocalMusicServer
{
    [RunInstaller(true)]
    public class Program : SimpleServiceApplication
    {
        public static void Main(string[] args)
        {
            var kernel = new StandardKernel(new Bindings());

            new Service(args,
                   ()=> kernel.GetAll<IWindowsService>().ToArray(),
                   installationSettings: (serviceInstaller, serviceProcessInstaller) =>
                   {
                       serviceInstaller.ServiceName = "OpenSonos.LocalMusicServer.Service";
                       serviceInstaller.StartType = ServiceStartMode.Automatic;
                       serviceProcessInstaller.Account = ServiceAccount.NetworkService;
                   },
                   configureContext: x => { x.Log = Console.WriteLine; },
                   registerContainer: () => new SimpleServicesToNinject(kernel))
           .Host();
        }
    }
}