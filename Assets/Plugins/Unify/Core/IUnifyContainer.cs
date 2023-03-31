using System;
using Plugins.Unify.Core.Builders.DependencyBuilder;

namespace Plugins.Unify.Core
{
    public interface IUnifyContainer
    {
        UnifyDependencyBuilder<TDependency> DefineDependency<TDependency>() where TDependency : class;
        object ResolveDependency(Type type, string id = default);
    }
}