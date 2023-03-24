using Unify.Core.Factories;
using Unify.Core.Installers;
using Unify.Example.Behaviours;
using Unify.Example.Factories;
using UnityEngine;

namespace Unify.Example.Installers
{
    public class ExampleUnifyInstallerWithFactory : BaseUnifyInstaller
    {
        private ExampleUnifyBehaviourWithFactory _exampleUnifyBehaviourWithFactory;
        
        public override void RegisterDependencies()
        {
            LocalContainer.RegisterDependency<ExampleUnifyObjectFactory>(new ExampleUnifyObjectFactory());
            LocalContainer.RegisterDependency<ExampleUnifyBehaviourWithFactory>(new GameObject().AddComponent<ExampleUnifyBehaviourWithFactory>());  
        }
    }
}