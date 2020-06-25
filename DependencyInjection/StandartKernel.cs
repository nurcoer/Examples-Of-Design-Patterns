using System;
using System.Collections.Generic;
using System.Reflection;
using Ninject;
using Ninject.Activation;
using Ninject.Activation.Blocks;
using Ninject.Components;
using Ninject.Modules;
using Ninject.Parameters;
using Ninject.Planning.Bindings;
using Ninject.Syntax;

namespace DependencyInjection
{
    internal class StandartKernel : IKernel
    {
        public INinjectSettings Settings => throw new NotImplementedException();

        public IComponentContainer Components => throw new NotImplementedException();

        public bool IsDisposed => throw new NotImplementedException();

        public event EventHandler Disposed;

        public void AddBinding(IBinding binding)
        {
            throw new NotImplementedException();
        }

        public IActivationBlock BeginBlock()
        {
            throw new NotImplementedException();
        }

        public IBindingToSyntax<T> Bind<T>()
        {
            throw new NotImplementedException();
        }

        public IBindingToSyntax<T1, T2> Bind<T1, T2>()
        {
            throw new NotImplementedException();
        }

        public IBindingToSyntax<T1, T2, T3> Bind<T1, T2, T3>()
        {
            throw new NotImplementedException();
        }

        public IBindingToSyntax<T1, T2, T3, T4> Bind<T1, T2, T3, T4>()
        {
            throw new NotImplementedException();
        }

        public IBindingToSyntax<object> Bind(params Type[] services)
        {
            throw new NotImplementedException();
        }

        public bool CanResolve(IRequest request)
        {
            throw new NotImplementedException();
        }

        public bool CanResolve(IRequest request, bool ignoreImplicitBindings)
        {
            throw new NotImplementedException();
        }

        public IRequest CreateRequest(Type service, Func<IBindingMetadata, bool> constraint, IEnumerable<IParameter> parameters, bool isOptional, bool isUnique)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IBinding> GetBindings(Type service)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<INinjectModule> GetModules()
        {
            throw new NotImplementedException();
        }

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public bool HasModule(string name)
        {
            throw new NotImplementedException();
        }

        public void Inject(object instance, params IParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public void Load(IEnumerable<INinjectModule> m)
        {
            throw new NotImplementedException();
        }

        public void Load(IEnumerable<string> filePatterns)
        {
            throw new NotImplementedException();
        }

        public void Load(IEnumerable<Assembly> assemblies)
        {
            throw new NotImplementedException();
        }

        public IBindingToSyntax<T1> Rebind<T1>()
        {
            throw new NotImplementedException();
        }

        public IBindingToSyntax<T1, T2> Rebind<T1, T2>()
        {
            throw new NotImplementedException();
        }

        public IBindingToSyntax<T1, T2, T3> Rebind<T1, T2, T3>()
        {
            throw new NotImplementedException();
        }

        public IBindingToSyntax<T1, T2, T3, T4> Rebind<T1, T2, T3, T4>()
        {
            throw new NotImplementedException();
        }

        public IBindingToSyntax<object> Rebind(params Type[] services)
        {
            throw new NotImplementedException();
        }

        public bool Release(object instance)
        {
            throw new NotImplementedException();
        }

        public void RemoveBinding(IBinding binding)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> Resolve(IRequest request)
        {
            throw new NotImplementedException();
        }

        public void Unbind<T>()
        {
            throw new NotImplementedException();
        }

        public void Unbind(Type service)
        {
            throw new NotImplementedException();
        }

        public void Unload(string name)
        {
            throw new NotImplementedException();
        }

        #region IDisposable Support
        private bool disposedValue = false; // Artık çağrıları algılama

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: yönetilen durumu (yönetilen nesneleri) bırakın.
                }

                // TODO: yönetilmeyen kaynakları (yönetilmeyen nesneleri) serbest bırakın ve aşağıda bir sonlandırıcıyı geçersiz kılın.
                // TODO: büyük alanları null olarak ayarlayın.

                disposedValue = true;
            }
        }

        // TODO: yalnızca yukarıdaki Dispose(bool disposing) ifadesi yönetilmeyen kaynakları serbest bırakacak koda sahipse sonlandırıcıyı geçersiz kılın.
        // ~StandartKernel() {
        //   // Bu kodu değiştirmeyin. Temizleme kodunu yukarıdaki Dispose(bool disposing) içine yerleştirin.
        //   Dispose(false);
        // }

        // Atılabilir deseni doğru uygulamak için bu kod eklendi.
        public void Dispose()
        {
            // Bu kodu değiştirmeyin. Temizleme kodunu yukarıdaki Dispose(bool disposing) içine yerleştirin.
            Dispose(true);
            // TODO: sonlandırıcı yukarıda geçersiz kılınırsa aşağıdaki satırın açıklamasını kaldırın.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}