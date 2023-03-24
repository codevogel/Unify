using Unify.Core;
using Unify.Core.Attributes;
using Unify.Core.Factories;
using UnityEngine;

namespace Unify.Example.Behaviours
{
    public class ExampleUnifyBehaviourWithFactory : UnifyBehaviour
    {
        private UnifyObjectFactory<FooBehaviour> _objectFactory;
        
        [Inject]
        public void Inject(UnifyObjectFactory<FooBehaviour> objectFactory)
        {
            _objectFactory = objectFactory;
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Space)) return;
            
            var foo = _objectFactory.CreateFromBuilder<FooBehaviour>();
            foo.DoSomething();
        }
    }
}