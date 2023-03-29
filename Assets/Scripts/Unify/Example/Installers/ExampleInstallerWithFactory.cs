using Unify.Core.Installers;
using Unify.Example.Behaviours;
using Unify.Example.Factories;
using UnityEngine;

namespace Unify.Example.Installers
{
    /// <summary>
    /// The ExampleInstallerWithFactory is an example implementation of the BaseUnifyInstaller.
    /// In this example, a BarBehaviourFactory and BarFactoryBehaviour are created and registered.
    /// </summary>
    public class ExampleInstallerWithFactory : BaseUnifyInstaller
    {
        public override void RegisterDependencies()
        {
            // Register a factory that instantiates BarBehaviours
            DefineDependency<BarBehaviourFactory>().FromInstance(new BarBehaviourFactory()).Register();
            
            // Register the behaviour that will use the BarDependencyFactory to instantiate BarBehaviours.
            var behaviourWithBarFactory = new GameObject("BehaviourWithBarFactory").AddComponent<BarFactoryBehaviour>();
            DefineDependency<BarFactoryBehaviour>().FromInstance(behaviourWithBarFactory).Register();
        }
    }
}