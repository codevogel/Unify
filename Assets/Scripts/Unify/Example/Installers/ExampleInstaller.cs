using Unify.Core.Installers;
using Unify.Example.Behaviours;
using Unify.Example.Factories;
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
            using (var builder = LocalContainer.RegisterDependency<string>().FromInstance(someStringDependency))
            {
                
            }
            
            // Register a FooBehaviour instance from the inspector with id "fromHierarchy"
            LocalContainer.RegisterDependency<FooBehaviour>().FromInstance(fooBehaviourInHierarchy).WithId("fromHierarchy");

            // Create FooBehaviour from installer and register it with id "fromCode" 
            var fooBehaviourFromCode = new GameObject("FooBehaviour From Code").AddComponent<FooBehaviour>();
            LocalContainer.RegisterDependency<FooBehaviour>().FromInstance(fooBehaviourInHierarchy).WithId("fromCode");
            
            // Create a BarBehaviour that has it's own dependencies
            var barBehaviour = new GameObject("BarBehaviourWithDependency").AddComponent<BarBehaviour>();
            LocalContainer.RegisterDependency<BarBehaviour>().FromInstance(barBehaviour);
        }
    }
}