using Example.Behaviours;
using Plugins.Unify.Core.Installers;
using UnityEngine;

namespace Example.Installers
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
            // Two ways of defining an IBaz dependency as a concrete implementation of BazBehaviour:
            var bazBehaviour = new GameObject("Baz behaviour").AddComponent<BazBehaviour>();
            DefineDependency<IBaz>().FromInstance(bazBehaviour).Register();
            // or:
            // DefineDependency<IBaz>().AsInterfaceTo<BazBehaviour>().FromComponentOnNewGameObject().WithId("otherMethod").Register();
            
            // Create an instance of Qux behaviour and register it.
            DefineDependency<QuxBehaviour>().FromComponentOnNewGameObject("Qux Behaviour").Register();
        }
    }
}