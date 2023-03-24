namespace Unify.Core.Factories
{
    public interface IObjectFactory
    {
        void RegisterRootContainer(IUnifyContainer rootContainer);
        
        T Create<T>(string name = default);
    }
}