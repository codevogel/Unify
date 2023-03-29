using Unify.Core.Installers;
using Unify.Example.Behaviours;
using UnityEngine;

namespace Unify.Example.Installers
{
    /// <summary>
    /// The ExampleInstallerWithInterfaces is an example implementation of the BaseUnifyInstaller.
    /// In this example we create an instance of BazBehaviour which implements IBaz, and then
    /// register a dependency of type IBaz using the BazBehaviour instance.
    /// We then create and register a QuxBehaviour (which depends on an implementation of IBaz). 
    /// </summary>
    public class ExampleInstallerWithInterfaces : UnifyMonoInstaller
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