using UnityEngine;

namespace Unify.Core.Factories
{
    public abstract class BaseUnifyObjectFactory : IObjectFactory
    {
        private IUnifyContainer _rootContainer;
        
        public void RegisterRootContainer(IUnifyContainer rootContainer)
        {
            _rootContainer = rootContainer;
        }

        public T Create<T>(string name = default)
        {
            return new GameObject(name, new[] { typeof(T) }).GetComponent<T>();
        }
    }
}