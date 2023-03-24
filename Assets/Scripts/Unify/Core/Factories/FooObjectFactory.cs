using System;
using Unify.Core.Factories.ObjectBuilder;
using Unify.Example.Behaviours;

namespace Unify.Core.Factories
{
    public class FooObjectFactory : UnifyObjectFactory<FooBehaviour>
    {
        public FooObjectFactory() : base(new UnifyObjectBuilder(new[] { typeof(FooBehaviour) }))
        {
        }
        
        public FooBehaviour CreateFromBuilder (string name = default)
        {
            var o = base.CreateFromBuilder<FooBehaviour>(name);
            o.Inject((string) _rootContainer.ResolveDependency(typeof(string)));
            return o;
        }

    }
    
}