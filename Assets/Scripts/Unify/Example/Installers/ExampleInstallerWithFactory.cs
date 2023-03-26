using Unify.Core.Installers;
using Unify.Example.Behaviours;
using Unify.Example.Factories;
using UnityEngine;

namespace Unify.Example.Installers
{
    public class ExampleInstallerWithFactory : BaseUnifyInstaller
    {
        public override void RegisterDependencies()
        {
            // Register a factory that instantiates BarBehaviours
            LocalContainer.RegisterDependency<BarDependencyFactory>(new BarDependencyFactory());
            
            // Register the behaviour that contains the BarDependencyFactory
            var behaviourWithBarFactory = new GameObject("BehaviourWithBarFactory").AddComponent<BehaviourWithBarFactory>();
            LocalContainer.RegisterDependency<BehaviourWithBarFactory>(behaviourWithBarFactory);
        }
    }
}