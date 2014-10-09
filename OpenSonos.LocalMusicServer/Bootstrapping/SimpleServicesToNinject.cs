using System;
using System.Collections.Generic;
using Ninject;
using SimpleServices;

namespace OpenSonos.LocalMusicServer.Bootstrapping
{
    public class SimpleServicesToNinject : IIocContainer
    {
        private readonly IKernel _kernel;

        public SimpleServicesToNinject(IKernel kernel)
        {
            _kernel = kernel;
        }

        public T GetType<T>()
        {
            return _kernel.Get<T>();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return _kernel.GetAll<T>();
        }

        public object Get(Type t)
        {
            return _kernel.Get(t);
        }

        public IEnumerable<object> GetAll(Type t)
        {
            return _kernel.GetAll(t);
        }
    }
}