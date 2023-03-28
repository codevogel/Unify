using Unify.Core.Installers;
using Unify.Example.Behaviours;
using UnityEngine;

namespace Unify.Example.Installers
{
    public class ExampleInstallerWithInterfaces : BaseUnifyInstaller
    {
        public override void RegisterDependencies()
        {
            // Create an instance of Baz behaviour and reference it through the interface IBaz
            var bazBehaviour = new GameObject("Baz behaviour").AddComponent<BazBehaviour>();
            LocalContainer.DefineDependency<IBaz>().FromInstance(bazBehaviour).Register();
            
            // Create an instance of Qux behaviour and register it.
            var quxBehaviour = new GameObject("Qux behaviour").AddComponent<QuxBehaviour>();
            LocalContainer.DefineDependency<QuxBehaviour>().FromInstance(quxBehaviour).Register();
        }
    }
}