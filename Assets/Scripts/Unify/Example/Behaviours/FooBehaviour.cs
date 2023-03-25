using Unify.Core;
using UnityEngine;

namespace Unify.Example.Behaviours
{
    /// <summary>
    /// A simple UnifyBehaviour that has no dependencies.
    /// </summary>
    public class FooBehaviour : UnifyBehaviour
    {
        private void Start()
        {
            DoSomething();
        }

        public void DoSomething()
        {
            Debug.Log($"FooBehaviour just did something from gameObject with name {gameObject.name}");
        }
    }
}