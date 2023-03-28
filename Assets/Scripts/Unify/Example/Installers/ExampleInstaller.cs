using Unify.Core.Installers;
using Unify.Example.Behaviours;
using UnityEngine;

namespace Unify.Example.Installers
{
    public class ExampleInstaller : BaseUnifyInstaller
    {
        public FooBehaviour fooBehaviourInHierarchy;
        public string someStringDependency;
        public override void RegisterDependencies()
        {
            // Register a string instance from the inspector
            LocalContainer.DefineDependency<string>().FromInstance(someStringDependency).Register();

            // Register a FooBehaviour instance from the inspector with id "fromHierarchy"
            LocalContainer.DefineDependency<FooBehaviour>().FromInstance(fooBehaviourInHierarchy).WithId("fromHierarchy").Register();

            // Create FooBehaviour from installer and register it with id "fromCode" 
            var fooBehaviourFromCode = new GameObject("FooBehaviour From Code").AddComponent<FooBehaviour>();
            LocalContainer.DefineDependency<FooBehaviour>().FromInstance(fooBehaviourFromCode).WithId("fromCode").Register();
            
            // Create a BarBehaviour that has it's own dependencies
            var barBehaviour = new GameObject("BarBehaviourWithDependency").AddComponent<BarBehaviour>();
            LocalContainer.DefineDependency<BarBehaviour>().FromInstance(barBehaviour).Register();
        }
    }
}