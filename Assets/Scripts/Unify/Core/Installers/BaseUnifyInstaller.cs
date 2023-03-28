using Unify.Core.Builders.DependencyBuilder;

namespace Unify.Core.Installers
{
    public abstract class BaseUnifyInstaller : UnifyInstaller, IBaseUnifyInstaller
    {
        public UnifyContainer LocalContainer { get; } = new UnifyContainer();

        public UnifyDependencyBuilder<TDependency> DefineDependency<TDependency>()
        {
            return LocalContainer.DefineDependency<TDependency>();
        }
    }
}