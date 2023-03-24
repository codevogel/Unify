using System;
using Unify.Core.Factories.ObjectBuilder;

namespace Unify.Core.Factories
{
    public abstract class UnifyObjectFactory<TObject> : IObjectFactory
    {
        protected IUnifyContainer _rootContainer;
        private readonly IObjectBuilder _objectBuilder;

        public UnifyObjectFactory(IObjectBuilder objectBuilder)
        {
            _objectBuilder = objectBuilder;
        }
        
        public void RegisterRootContainer(IUnifyContainer rootContainer)
        {
            _rootContainer = rootContainer;
        }

        protected virtual T CreateFromBuilder<T> (string name = default)
        {
            return _objectBuilder.Build<T>(name);
        }
    }
    
}