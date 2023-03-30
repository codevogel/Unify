using NUnit.Framework;
using Unify.TestFramework;

namespace Unify.Example.Tests
{
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
            Assert.AreEqual("ayy", _exampleTestInstaller.SomeDependency );
        }
    }
}