using Unify.Core.Factories.ObjectBuilder;
using Unify.Example.Behaviours;

namespace Unify.Core.Factories
{
    public class FooObjectFactory : UnifyObjectFactory<FooBehaviour>
    {

        protected override void InjectDependenciesInto(FooBehaviour o)
        {
            o.Inject((string) _rootContainer.ResolveDependency(typeof(string)));
        }


    }
    
}