using Unify.Core.Attributes;
using Unify.Core.Factories;
using Unify.Example.Behaviours;

namespace Unify.Example.Factories
{
    /// <summary>
    /// The BarBehaviourFactory is an example implementation of the BaseUnifyObjectFactory that manually
    /// injects the needed dependencies for BarBehaviour.
    /// </summary>
    public class BarBehaviourFactory : BaseUnifyObjectFactory<BarBehaviour>
    {
        // Manual implementation of injecting the dependencies are required for factories.
        protected override void InjectDependenciesInto(BarBehaviour o)
        {
            o.Inject(
                ResolveFromContainer<string>(),
                ResolveFromContainer<FooBehaviour>("fromCode"), 
                ResolveFromContainer<FooBehaviour>("fromHierarchy")
            );
        }
        
        // Can be extended to make room for manually overriding certain dependencies:
        [FactoryOverride("withCustomString")]
        public void InjectDependenciesWithCustomString(BarBehaviour o, string customString)
        {
            o.Inject(
                customString,
                ResolveFromContainer<FooBehaviour>("fromCode"), 
                ResolveFromContainer<FooBehaviour>("fromHierarchy")
            );
        }
    }
    
}