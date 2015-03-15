using System.IO.Abstractions;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Modules;
using OpenSonos.LocalMusicServer.Browsing;
using OpenSonos.LocalMusicServer.Browsing.MusicRepositories;
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
            kernel.Bind(x => x.FromAssemblyContaining<IFileSystem>().SelectAllClasses().BindAllInterfaces());

            kernel.Rebind<ServerConfiguration>().ToMethod(x => ServerConfigurationFactory.LoadConfiguration()).InSingletonScope();
            kernel.Rebind<IIdentityProvider>().To<IdentityProvider>().InSingletonScope();
            kernel.Rebind<ISearchProvider>().To<TopLevelDirectorySearchProvider>().InSingletonScope(); 
            kernel.Rebind<SmapiSoapControllerDependencies>().To<SmapiSoapControllerDependencies>().InSingletonScope();

            SmapiSoapController.Dependencies = () => kernel.Get<SmapiSoapControllerDependencies>();

            kernel.Bind<LocalMusicServerFactory>().ToMethod(context => new LocalMusicServerFactory(typeof(SmapiSoapController)));
        }

        public void OnUnload(IKernel kernel)
        {
        }

        public void OnVerifyRequiredModules()
        {
        }

    }
}