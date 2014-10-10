using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Modules;
using OpenSonos.LocalMusicServer.Browsing;
using OpenSonos.LocalMusicServer.Smapi;

namespace OpenSonos.LocalMusicServer.Bootstrapping
{
    public class Bindings : INinjectModule
    {
        public string Name { get { return "Default"; } }
        public IKernel Kernel { get; private set; }

        public void OnLoad(IKernel kernel)
        {
            kernel.Bind(x => x.FromThisAssembly().SelectAllClasses().BindAllInterfaces());
            kernel.Bind(x => x.FromAssemblyContaining<SonosPlayer>().SelectAllClasses().BindAllInterfaces());
            
            kernel.Rebind<IIdentityProvider>().To<GuidIdentityProvider>().InSingletonScope();
            kernel.Rebind<ServerConfiguration>().ToMethod(x => ServerConfigurationFactory.LoadConfiguration()).InSingletonScope();

            SmapiSoapController.MusicRepository = () => kernel.Get<IMusicRepository>();
            SmapiSoapController.IdentityProvider = () => kernel.Get<IIdentityProvider>();

            kernel.Bind<ServerBuilder>().ToMethod(context => Server.ImplementedBy<SmapiSoapController>());
        }

        public void OnUnload(IKernel kernel)
        {
        }

        public void OnVerifyRequiredModules()
        {
        }

    }
}