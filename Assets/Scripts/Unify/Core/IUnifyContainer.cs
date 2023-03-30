using System;
using Unify.Core.Builders.DependencyBuilder;

namespace Unify.Core
{
    public interface IUnifyContainer
    {
        UnifyDependencyBuilder<TDependency> DefineDependency<TDependency>() where TDependency : class;
        object ResolveDependency(Type type, string id = default);
    }
}