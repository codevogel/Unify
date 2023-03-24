using Unify.Core;
using Unify.Core.Attributes;
using UnityEngine;

namespace Unify.Example.Behaviours
{
    public class FooBehaviour : UnifyBehaviour
    {

        private string _someDependency;
        
        [Inject]
        public void Inject(string someDependency)
        {
            _someDependency = someDependency;
        }
        
        public void DoSomething()
        {
            Debug.Log($"I am doing something in FooBehaviour with someDependency: {_someDependency}!");
        }


    }
}