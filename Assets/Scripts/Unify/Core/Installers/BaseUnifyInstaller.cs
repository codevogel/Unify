namespace Unify.Core.Installers
{
    public abstract class BaseUnifyInstaller : UnifyInstaller, IBaseUnifyInstaller
    {
        public UnifyContainer LocalContainer { get; } = new UnifyContainer();
    }
}