using Plugins.Unify.Core.Builders.DependencyBuilder;

namespace Plugins.Unify.Core.Installers
{
    /// Base interface for unify installers.
    public interface IUnifyInstaller
    {
        public UnifyContainer LocalContainer { get; }

        // A unify installer needs to be able to register dependencies.
        public void RegisterDependencies();

        public UnifyDependencyBuilder<TDependency> DefineDependency<TDependency>() where TDependency : class;

    }
}