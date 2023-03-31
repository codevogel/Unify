using System.Collections.Generic;

namespace Plugins.Unify.Core.Installers
{
    public class RootInstallerMono : UnifyBehaviour
    {

        private static readonly RootInstaller RootInstaller = new RootInstaller();
        public List<UnifyMonoInstaller> monoInstallers;
        
        private void Awake()
        {
            RootInstaller.RegisterInstallers(monoInstallers);
            RootInstaller.InjectDependencies();
        }
    }
}