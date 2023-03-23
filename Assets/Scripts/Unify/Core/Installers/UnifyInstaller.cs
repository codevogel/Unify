using UnityEngine;

namespace Unify.Core.Installers
{
    /// The UnifyInstaller class provides the base template for a UnifyInstaller. 
    public abstract class UnifyInstaller : MonoBehaviour, IUnifyInstaller
    {
        public abstract void RegisterDependencies();
    }
}