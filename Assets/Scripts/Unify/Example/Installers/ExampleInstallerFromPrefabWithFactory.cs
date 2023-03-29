using Unify.Core.Installers;
using Unify.Example.Behaviours;
using Unify.Example.Factories;

namespace Unify.Example.Installers
{
    /// <summary>
    /// The ExampleInstallerWithFactory is an example implementation of the BaseUnifyInstaller.
    /// In this example, a BarBehaviourFactory and BarFactoryBehaviour are created and registered.
    /// </summary>
    public class ExampleInstallerFromPrefabWithFactory : BaseUnifyInstaller
    {

        public BarFactoryBehaviour BarFactoryBehaviourPrefab;
        
        public override void RegisterDependencies()
        {
            // Register a factory that instantiates BarBehaviours
            DefineDependency<BarBehaviourFactory>().FromInstance(new BarBehaviourFactory()).Register();
            
            // Register the behaviour that will use the BarDependencyFactory to instantiate BarBehaviours.
            DefineDependency<BarFactoryBehaviour>().FromPrefab(BarFactoryBehaviourPrefab.gameObject).Register();
        }
    }
}