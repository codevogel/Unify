using System;
using Unify.Core.Factories.ObjectBuilder;

namespace Unify.Core.Factories
{
    public abstract class UnifyObjectFactory<TObject> : IObjectFactory
    {
        protected IUnifyContainer _rootContainer;
        private readonly IObjectBuilder<TObject> _objectBuilder;

        protected UnifyObjectFactory()
        {
            _objectBuilder = new UnifyObjectBuilder<TObject>();
        }

        public void RegisterRootContainer(IUnifyContainer rootContainer)
        {
            _rootContainer = rootContainer;
        }

        private TObject CreateFromBuilder (string name = default)
        {
            return _objectBuilder.Build(name);
        }

        protected abstract void InjectDependenciesInto(TObject o);

        public TObject Create(string name = default)
        {
            var o = CreateFromBuilder(name);
            InjectDependenciesInto(o);
            return o;
        }
    }
    
}