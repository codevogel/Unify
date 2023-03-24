using Unify.Core.Factories.ObjectBuilder;

namespace Unify.Core.Factories
{
    public interface IObjectFactory
    {
        void RegisterRootContainer(IUnifyContainer rootContainer);
        
        T CreateFromBuilder<T>(string name = default);
    }
}