using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ServiceProcess;
using OpenSonos.LocalMusicServer.Bootstrapping;
using SimpleServices;

namespace OpenSonos.LocalMusicServer
{
    [RunInstaller(true)]
    public class Program : SimpleServiceApplication
    {
        public static void Main(string[] args)
        {
            new Service(args,
                   new List<IWindowsService> { new SmbMusicService(), new SonosPlayerDiscoveryService() }.ToArray,
                   installationSettings: (serviceInstaller, serviceProcessInstaller) =>
                   {
                       serviceInstaller.ServiceName = "OpenSonos.LocalMusicServer.Service";
                       serviceInstaller.StartType = ServiceStartMode.Automatic;
                       serviceProcessInstaller.Account = ServiceAccount.LocalService;
                   },
                   configureContext: x => { x.Log = Console.WriteLine; })
           .Host();
        }
    }
}