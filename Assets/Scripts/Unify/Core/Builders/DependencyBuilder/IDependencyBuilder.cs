using System;

namespace Unify.Core.Builders.DependencyBuilder
{
    public interface IDependencyBuilder<in TDependency> : IDisposable
    {
        public IDependencyBuilder<TDependency> FromInstance(TDependency instance);

        public IDependencyBuilder<TDependency> WithId(string id);
        void Register();
    }
}