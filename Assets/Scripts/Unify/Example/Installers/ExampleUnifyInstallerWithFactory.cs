using System;
using Unify.Core.Factories;
using Unify.Core.Installers;
using Unify.Example.Behaviours;
using UnityEngine;

namespace Unify.Example.Installers
{
    public class ExampleUnifyInstallerWithFactory : BaseUnifyInstaller
    {
        private ExampleUnifyBehaviourWithFactory _exampleUnifyBehaviourWithFactory;
        
        public override void RegisterDependencies()
        {
            var factory = new UnifyObjectFactory<FooBehaviour>();
            LocalContainer.RegisterDependency<UnifyObjectFactory<FooBehaviour>>(factory);
            LocalContainer.RegisterDependency<ExampleUnifyBehaviourWithFactory>(new GameObject().AddComponent<ExampleUnifyBehaviourWithFactory>());  
        }
    }
}