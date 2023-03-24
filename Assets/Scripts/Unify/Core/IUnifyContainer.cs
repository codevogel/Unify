using System;

namespace Unify.Core
{
    public interface IUnifyContainer
    {
        void RegisterDependency<T>(object instance, string id = default);
        object ResolveDependency(Type type, string id = default);
    }
}