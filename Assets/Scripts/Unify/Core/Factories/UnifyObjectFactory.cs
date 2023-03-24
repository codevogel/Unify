using System;
using Unify.Core.Factories.ObjectBuilder;

namespace Unify.Core.Factories
{
    public class UnifyObjectFactory<TObject> : IObjectFactory
    {
        private IUnifyContainer _rootContainer;
        private readonly IObjectBuilder _objectBuilder;

        public UnifyObjectFactory()
        {
            _objectBuilder = new UnifyObjectBuilder(new []{ typeof(TObject)});
        }
        
        public UnifyObjectFactory(Type[] parameters)
        {
            _objectBuilder = new UnifyObjectBuilder(parameters: parameters);
        }
        
        public void RegisterRootContainer(IUnifyContainer rootContainer)
        {
            _rootContainer = rootContainer;
        }

        public T CreateFromBuilder<T> (string name = default)
        {
            return _objectBuilder.Build<T>(name);
        }
    }
    
}