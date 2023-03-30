using Unify.Core.Attributes;
using Unify.TestFramework;

namespace Unify.Example.Tests
{
    public class ExampleTestInstaller : UnifyTestInstaller
    {
        public string SomeDependency;

        [Inject]
        public void Inject(string someDependency)
        {
            SomeDependency = someDependency;
        }
        
        public override void RegisterDependencies()
        {
            DefineDependency<string>().FromInstance("ayy").Register();
        }
    }
}