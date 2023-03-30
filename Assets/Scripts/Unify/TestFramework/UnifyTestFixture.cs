
using System.Collections.Generic;
using NUnit.Framework;
using Unify.Core.Installers;

namespace Unify.TestFramework
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
            _rootInstaller.InjectDependenciesInto(SubInstallers);
        }

        protected abstract void AddSubInstallers();
    }
}