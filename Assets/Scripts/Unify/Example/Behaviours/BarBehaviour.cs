using Unify.Core;
using Unify.Core.Attributes;
using UnityEngine;

namespace Unify.Example.Behaviours
{
    /// <summary>
    /// A UnifyBehaviour that has dependencies on other UnifyBehaviours. In this case, it depends on:
    ///  - a global string dependency
    ///  - two different instances of FooBehaviour
    /// </summary>
    public class BarBehaviour : UnifyBehaviour
    {

        public string SomeStringDependency;
        private FooBehaviour _theFooBehaviourFromCode;
        private FooBehaviour _theFooBehaviourFromHierarchy;
        
        [Inject]
        public void Inject(
            string someStringDependency, 
            [InjectWithId("fromCode")] FooBehaviour fooBehaviourFromCode, 
            [InjectWithId("fromHierarchy")] FooBehaviour fooBehaviourFromHierarchy)
        {
            SomeStringDependency = someStringDependency;
            _theFooBehaviourFromCode = fooBehaviourFromCode;
            _theFooBehaviourFromHierarchy = fooBehaviourFromHierarchy;
        }

        private void Start()
        {
            Debug.Log("BarBehaviourWithDependencies has access to: " + SomeStringDependency);
            Debug.Log("BarBehaviourWithDependencies will now do something on: " + _theFooBehaviourFromCode);
            _theFooBehaviourFromCode.DoSomething();
            Debug.Log("BarBehaviourWithDependencies will now do something on: " + _theFooBehaviourFromHierarchy);
            _theFooBehaviourFromHierarchy.DoSomething();
        }
    }
}