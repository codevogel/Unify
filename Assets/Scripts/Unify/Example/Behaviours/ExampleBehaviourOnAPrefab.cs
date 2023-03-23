
using Unify.Core;
using UnityEngine;

namespace Unify.Example.Behaviours
{
    public class ExampleBehaviourOnAPrefab : UnifyBehaviour
    {
        public void DoSomething()
        {
            Debug.Log("I am doing something after having been instantiated from a prefab!");
        }
    }
}
