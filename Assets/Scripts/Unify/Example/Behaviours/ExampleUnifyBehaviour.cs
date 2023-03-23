using Unify.Core;
using Unify.Core.Attributes;
using UnityEngine;

namespace Unify.Example.Behaviours
{
    public class ExampleUnifyBehaviour : UnifyBehaviour
    {
        private int _intDependency;
        private int _intDependency2;
        private string _stringDependency;
        private ExampleReferencedBehaviour _exampleReferencedBehaviour;
        private ExampleReferencedBehaviourWithItsOwnDependencies _exampleReferencedBehaviourWithItsOwnDependencies;
        private ExampleBehaviourOnAPrefab _exampleBehaviourOnAPrefab;

        [Inject]
        public void InjectDependencies(
            [InjectWithId("id1")] int intDependency, 
            [InjectWithId("id2")] int intDependency2, 
            string stringDependency, 
            ExampleReferencedBehaviour exampleReferencedBehaviour,
            ExampleReferencedBehaviourWithItsOwnDependencies exampleReferencedBehaviourWithItsOwnDependencies,
            ExampleBehaviourOnAPrefab exampleBehaviourOnAPrefab)
        {
            _intDependency = intDependency;
            _intDependency2 = intDependency2;
            _stringDependency = stringDependency;
            _exampleReferencedBehaviour = exampleReferencedBehaviour;
            _exampleReferencedBehaviourWithItsOwnDependencies = exampleReferencedBehaviourWithItsOwnDependencies;
            _exampleBehaviourOnAPrefab = exampleBehaviourOnAPrefab;
        }

        private void Start()
        {
            Debug.Log("I now have access to: " + _intDependency + " and " + _intDependency2 + " and " + _stringDependency);
            _exampleReferencedBehaviour.DoSomething();
            _exampleReferencedBehaviourWithItsOwnDependencies.DoSomething();

            var exampleBehaviourOnAPrefab = GameObject.Instantiate(_exampleBehaviourOnAPrefab);
            exampleBehaviourOnAPrefab.DoSomething();
        }
    }
}