using Unify.Core.Attributes;
using Unify.Core.Factories;
using Unify.Example.Behaviours;

namespace Unify.Example.Factories
{
    public class BarDependencyFactory : BaseUnifyObjectFactory<BarBehaviour>
    {
        // Manually implementation of injecting the dependencies are required for factories.
        protected override void InjectDependenciesInto(BarBehaviour o)
        {
            o.Inject(
                (string) RootContainer.ResolveDependency(typeof(string)),
                (FooBehaviour) RootContainer.ResolveDependency(typeof(FooBehaviour), "fromCode"), 
                (FooBehaviour) RootContainer.ResolveDependency(typeof(FooBehaviour), "fromHierarchy")
            );
        }
        
        // Can be extended to make room for manually overriding certain dependencies:
        [FactoryOverride("withCustomString")]
        public void InjectDependenciesWithCustomString(BarBehaviour o, string customString)
        {
            o.Inject(
                customString,
                (FooBehaviour) RootContainer.ResolveDependency(typeof(FooBehaviour), "fromCode"), 
                (FooBehaviour) RootContainer.ResolveDependency(typeof(FooBehaviour), "fromHierarchy")
            );
        }
    }
    
}