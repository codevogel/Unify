using Example.Behaviours;
using Plugins.Unify.Core.Installers;
using UnityEngine;

namespace Example.Installers
{
    /// <summary>
    /// The ExampleInstallerWithFactory is an example implementation of the BaseUnifyInstaller.
    /// In this example we do a couple of things:
    /// - We register a string dependency instance from the inspector field exposed on this installer.
    /// - We register a FooBehaviour that already existed in the hierarchy and was linked from the inspector with an id "fromHierarchy".
    /// - We instantiate and then register a FooBehaviour with an id "fromCode".
    /// - We then create and register a QuxBehaviour (which depends on a string, and two unique implementations of FooBehaviour). 
    /// </summary>
    public class ExampleInstaller : UnifyMonoInstaller
    {
        public FooBehaviour FooBehaviourInHierarchy;
        public string SomeStringDependency;
        public override void RegisterDependencies()
        {
            // Register a string instance from the inspector
            DefineDependency<string>().FromInstance(SomeStringDependency).Register();

            // Register a FooBehaviour instance from the inspector with id "fromHierarchy"
            DefineDependency<FooBehaviour>().FromInstance(FooBehaviourInHierarchy).WithId("fromHierarchy").Register();

            // Create FooBehaviour from installer and register it with id "fromCode" 
            DefineDependency<FooBehaviour>().FromComponentOnNewGameObject("FooBehaviour From Code").WithId("fromCode").Register();
            
            // Create a BarBehaviour that has it's own dependencies (we've registered it's dependencies above)
            var barBehaviour = new GameObject("BarBehaviourWithDependency").AddComponent<BarBehaviour>();
            DefineDependency<BarBehaviour>().FromInstance(barBehaviour).Register();
        }
    }
}