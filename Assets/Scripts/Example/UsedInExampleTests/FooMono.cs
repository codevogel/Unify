using Plugins.Unify.Core;
using Plugins.Unify.Core.Attributes;

namespace Example.UsedInExampleTests
{
    public class FooMono : UnifyBehaviour
    {
        public IFoo Foo;

        [Inject]
        public void Inject(IFoo foo)
        {
            Foo = foo;
        }

        public int TakeDamage(int damage) => Foo.TakeDamage(damage);
    }
}