using System.Collections.Generic;
using NUnit.Framework;
using Plugins.Unify.Core.Installers;

namespace Plugins.Unify.TestFramework
{
    [TestFixture]
    public abstract class UnifyTestFixture
    {
        private RootInstaller _rootInstaller;
        protected readonly List<UnifyTestInstaller> SubInstallers = new();

        [SetUp]
        public void Setup()
        {
            AddSubInstallers();
            _rootInstaller = new RootInstaller();
            _rootInstaller.RegisterInstallers(SubInstallers);
            _rootInstaller.InjectDependencies();
        }

        [TearDown]
        public void Teardown()
        {
            _rootInstaller = null;
        }

        protected abstract void AddSubInstallers();

        public TObject Resolve<TObject>(string id = default)
        {
            return _rootInstaller.Resolve<TObject>(id);
        }
    }
}