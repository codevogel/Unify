using System;
using UnityEngine;

namespace Plugins.Unify.Core.Builders.DependencyBuilder
{
    public interface IDependencyBuilder<in TDependency> : IDisposable
    {
        public IDependencyBuilder<TDependency> FromComponentOnNewGameObject(string name = default);
        public IDependencyBuilder<TDependency> FromPrefab(GameObject gameObjectWithDependencyAttached);

        public IDependencyBuilder<TDependency> FromInstance(TDependency instance);
        public IDependencyBuilder<TDependency> FromSubstitute();
        public IDependencyBuilder<TDependency> WithId(string id);
        public IDependencyBuilder<TDependency> AsInterfaceTo<TConcrete>();

        public void Register();

    }
}