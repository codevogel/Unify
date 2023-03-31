using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Plugins.Unify.Core.Builders.DependencyBuilder
{
    public interface IDependencyBuilder<in TDependency> : IDisposable
    {
        public IDependencyBuilder<TDependency> FromComponentOnGameObject(GameObject gameObject, string name = default);
        public IDependencyBuilder<TDependency> FromComponentOn<TComponent>(TComponent component, string name = default) where TComponent : Component;
        public IDependencyBuilder<TDependency> FromComponentOnNewGameObject(string name = default);
        public IDependencyBuilder<TDependency> FromPrefab(GameObject gameObjectWithDependencyAttached);
        public IDependencyBuilder<TDependency> FromPrefabResource(Object prefab);
        public IDependencyBuilder<TDependency> FromInstance(TDependency instance);
        public IDependencyBuilder<TDependency> FromSubstitute();
        public IDependencyBuilder<TDependency> WithId(string id);
        public IDependencyBuilder<TDependency> AsInterfaceTo<TConcrete>();

        public void Register();

    }
}