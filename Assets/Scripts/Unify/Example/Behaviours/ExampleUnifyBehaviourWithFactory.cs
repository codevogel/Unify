using System;
using Unify.Core;
using Unify.Core.Attributes;
using Unify.Core.Factories;
using Unify.Example.Factories;
using UnityEngine;

namespace Unify.Example.Behaviours
{
    public class ExampleUnifyBehaviourWithFactory : UnifyBehaviour
    {
        private ExampleUnifyObjectFactory _objectFactory;
        
        [Inject]
        public void Inject(ExampleUnifyObjectFactory objectFactory)
        {
            _objectFactory = objectFactory;
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Space)) return;
            
            var foo = _objectFactory.Create<FooBehaviour>();
            foo.DoSomething();
        }
    }
}