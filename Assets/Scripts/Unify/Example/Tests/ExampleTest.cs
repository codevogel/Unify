using NUnit.Framework;
using Unify.TestFramework;

namespace Unify.Example.Tests
{
    public class ExampleTestInstaller : UnifyTestInstaller
    {
        public override void RegisterDependencies()
        {
            DefineDependency<string>().FromInstance("ayy").Register();
        }
    }
    
    public class ExampleTest : UnifyTestFixture
    {
        private ExampleTestInstaller _exampleTestInstaller = new ExampleTestInstaller();

        protected override void AddSubInstallers()
        {
            SubInstallers.Add(_exampleTestInstaller);
        }

        [Test]
        public void SomeTest()
        {
            var someStringDependency = Resolve<string>();
            Assert.AreEqual("ayy",  someStringDependency);
        }
    }
}