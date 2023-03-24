using Unify.Core;
using Unify.Core.Attributes;
using Unify.Core.Factories;
using UnityEngine;

namespace Unify.Example.Behaviours
{
    public class ExampleUnifyBehaviourWithFactory : UnifyBehaviour
    {
        private FooObjectFactory _objectFactory;
        
        [Inject]
        public void Inject(FooObjectFactory objectFactory)
        {
            _objectFactory = objectFactory;
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Space)) return;
            
            var foo = _objectFactory.CreateFromBuilder();
            foo.DoSomething();
        }
    }
}