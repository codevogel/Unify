using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unify.Core.Attributes;

namespace Unify.Core.Installers
{
    /// The RootInstaller contains the UnifyContainer that all other UnifyContainers will resolve into.
    /// In our project, we will use only a single instance of the RootInstaller.
    /// We can't make this installer static however, since it needs to inherit from MonoBehaviour.
    public class RootInstaller : UnifyInstaller
    {
        protected static UnifyContainer Root = new UnifyContainer();

        // Keeps track of a list of all BaseDependencyInstallers that need to be installed into the root container.
        // We can assign these through the Unity Inspector.
        public List<BaseUnifyInstaller> Installers;

        public override void RegisterDependencies()
        {
            foreach (var installer in Installers)
            {
                // Registers each installers' local dependencies, then register that container into the root container.
                installer.RegisterDependencies();
                Root.RegisterDependenciesFrom(installer.LocalContainer);
            }
        }

        // This will be our entry point for our dependency injection framework.
        // This function gets called and subsequently registers all the dependencies, then injects them into
        // any UnifyBehaviours that need them.
        public void InstallGame()
        {
            RegisterDependencies();
            InjectDependencies();
        }

        private void InjectDependencies()
        {
            // Find all UnifyBehaviours in the scene.
            var unifyBehaviours = FindObjectsOfType<UnifyBehaviour>();

            foreach (var unifyBehaviour in unifyBehaviours)
            {
                // Get all methods with the [Inject] attribute.
                var injectMethods = unifyBehaviour.GetType()
                    .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .Where(m => m.GetCustomAttributes(typeof(InjectAttribute), true).Length > 0)
                    .ToList();

                foreach (var method in injectMethods)
                {
                    // Get the parameters of the method
                    var parameters = method.GetParameters();

                    var dependencies = new object[parameters.Length];

                    // Invoke the method with the resolved dependencies
                    for (var i = 0; i < parameters.Length; i++)
                    {
                        var param = parameters[i];
                        var paramAttributes = param.GetCustomAttributes(typeof(InjectWithIdAttribute)).ToArray();
                        if (paramAttributes.Length > 1)
                            throw new Exception("Multiple InjectWithIdAttribute attributes found on a parameter in an inject function.");
                        var id = paramAttributes.Length == 1 ? ((InjectWithIdAttribute)paramAttributes[0]).ID : default;
                        dependencies[i] = Root.ResolveDependency(param.ParameterType, id);
                    }

                    method.Invoke(unifyBehaviour, dependencies);
                }
            }
        }

        private void Awake()
        {
            InstallGame();
        }
    }
}