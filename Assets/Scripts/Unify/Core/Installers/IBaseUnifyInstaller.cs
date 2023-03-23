namespace Unify.Core.Installers
{
    /// The BaseUnifyInstaller interface also has a reference to a local UnifyContainer.
    public interface IBaseUnifyInstaller : IUnifyInstaller
    {
        public UnifyContainer LocalContainer { get; }
    }
}