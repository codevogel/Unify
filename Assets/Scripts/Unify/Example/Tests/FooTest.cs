using NUnit.Framework;
using Unify.TestFramework;

namespace Unify.Example.Tests
{
    public class FooTestInstaller : UnifyTestInstaller
    {
        public override void RegisterDependencies()
        {
            DefineDependency<Foo>().FromInstance(new Foo(10)).Register();
        }
    }
    
    public class FooTest : UnifyTestFixture
    {
        protected override void AddSubInstallers()
        {
            SubInstallers.Add(new FooTestInstaller());
        }

        [Test]
        public void TakeDamageReducesHealth()
        {
            var foo = Resolve<Foo>();
            Assert.NotNull(foo);
            Assert.AreEqual(7,  foo.TakeDamage(3));
        }
    }
}