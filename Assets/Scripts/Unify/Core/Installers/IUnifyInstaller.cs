namespace Unify.Core.Installers
{
    /// Base interface for unify installers.
    public interface IUnifyInstaller
    {
        // A unify installer needs to be able to register dependencies.
        public void RegisterDependencies();
    }
}