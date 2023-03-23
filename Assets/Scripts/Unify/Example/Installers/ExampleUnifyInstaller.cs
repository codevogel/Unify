using Unify.Core.Installers;
using Unify.Example.Behaviours;

namespace Unify.Example.Installers
{
    public class ExampleUnifyInstaller : BaseUnifyInstaller
    {
        public int intDependency;
        public int intDependency2;
        public string stringDependency;
        public string otherStringDependency;

        public ExampleReferencedBehaviour exampleReferencedBehaviour;
        public ExampleReferencedBehaviourWithItsOwnDependencies exampleReferencedBehaviourWithItsOwnDependencies;
        public ExampleBehaviourOnAPrefab exampleBehaviourOnAPrefab;
    
        public override void RegisterDependencies()
        {
            LocalContainer.RegisterDependency<int>(intDependency, "id1");
            LocalContainer.RegisterDependency<int>(intDependency2, "id2");
            LocalContainer.RegisterDependency<string>(stringDependency);
            LocalContainer.RegisterDependency<string>(otherStringDependency, "otherStringDependency");
            LocalContainer.RegisterDependency<ExampleReferencedBehaviour>(exampleReferencedBehaviour);
            LocalContainer.RegisterDependency<ExampleReferencedBehaviourWithItsOwnDependencies>(exampleReferencedBehaviourWithItsOwnDependencies);
            LocalContainer.RegisterDependency<ExampleBehaviourOnAPrefab>(exampleBehaviourOnAPrefab);
        }
    }
}