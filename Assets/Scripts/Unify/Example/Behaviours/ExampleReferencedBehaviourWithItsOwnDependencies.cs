using Unify.Core;
using Unify.Core.Attributes;
using UnityEngine;

namespace Unify.Example.Behaviours
{
    public class ExampleReferencedBehaviourWithItsOwnDependencies : UnifyBehaviour
    {

        private string _ownStringDependency;

        [Inject]
        public void Inject([InjectWithId("otherStringDependency")] string ownStringDependency)
        {
            this._ownStringDependency = ownStringDependency;
        }
    
        public void DoSomething()
        {
            Debug.Log($"This does something with another dependency: {_ownStringDependency}");
        }
    }
}
