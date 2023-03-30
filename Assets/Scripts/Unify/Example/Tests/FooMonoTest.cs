using NSubstitute;
using NUnit.Framework;
using Unify.Example.Tests.UsedInExampleTest;
using Unify.TestFramework;
using UnityEngine;

namespace Unify.Example.Tests
{
    public class FooMonoTestInstaller : UnifyTestInstaller
    {
        public override void RegisterDependencies()
        {
            DefineDependency<IFoo>().FromSubstitute().Register();
            DefineDependency<FooMono>().FromInstance(new GameObject().AddComponent<FooMono>()).Register();
        }
    }
    
    public class FooMonoTest : UnifyTestFixture
    {
        protected override void AddSubInstallers()
        {
            SubInstallers.Add(new FooMonoTestInstaller());
        }

        [Test]
        public void TakeDamageDelegatesToHumbleObject()
        {
            var fooMono = Resolve<FooMono>();
            fooMono.TakeDamage(3);
            fooMono.Foo.Received().TakeDamage(3);
        }
    }
}