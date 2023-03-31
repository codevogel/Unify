using Plugins.Unify.Core.Builders.DependencyBuilder;
using UnityEngine;

namespace Plugins.Unify.Core.Installers
{
    /// The UnifyInstaller class provides the base template for a UnifyInstaller. 
    public abstract class UnifyMonoInstaller : MonoBehaviour, IUnifyInstaller
    {
        public UnifyContainer LocalContainer { get; } = new UnifyContainer();
        public abstract void RegisterDependencies();

        public UnifyDependencyBuilder<TDependency> DefineDependency<TDependency>() where TDependency : class
        {
            return LocalContainer.DefineDependency<TDependency>();
        }
    }
}