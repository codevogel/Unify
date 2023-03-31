using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Plugins.Unify.Core.Attributes;
using UnityEngine;

namespace Plugins.Unify.Core.Installers
{
    /// The RootInstaller contains the UnifyContainer that all other UnifyContainers will resolve into.
    /// In our project, we will use only a single instance of the RootInstaller.
    /// We can't make this installer static however, since it needs to inherit from MonoBehaviour.
    [DefaultExecutionOrder(-1)]
    public class RootInstaller
    {
        private UnifyContainer _root = new UnifyContainer();

        public void RegisterInstallers(IEnumerable<IUnifyInstaller> installers)
        {
            foreach (var installer in installers)
            {
                // Registers each installers' local dependencies, then register that container into the root container.
                installer.RegisterDependencies();
                _root.RegisterDependenciesAndFactoriesFrom(installer.LocalContainer);
            }
        }

        public void InjectDependencies()
        {
            // TODO: This can result into injecting dependencies twice
            InjectDependenciesInto(_root.RegisteredObjects);
            InjectDependenciesInto(UnityEngine.Object.FindObjectsOfType<UnifyBehaviour>());
        }

        private void InjectDependenciesInto(IEnumerable objects)
        {
            foreach (var objectToInject in objects)
            {
                // Get all methods with the [Inject] attribute.
                var injectMethods = objectToInject.GetType()
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
                        dependencies[i] = _root.ResolveDependency(param.ParameterType, id);
                    }

                    method.Invoke(objectToInject, dependencies);
                }
            }
        }

        public TObject Resolve<TObject>(string id)
        {
            return (TObject) _root.ResolveDependency(typeof(TObject), id);
        }
    }
}