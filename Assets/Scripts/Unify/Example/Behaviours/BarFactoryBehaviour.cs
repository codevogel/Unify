using Unify.Core;
using Unify.Core.Attributes;
using Unify.Example.Factories;
using UnityEditor;
using UnityEngine;

namespace Unify.Example.Behaviours
{
    /// <summary>
    /// The BarFactoryBehaviour is an example UnifyBehaviour that has a factory that produces BarBehaviours in runtime.
    /// It creates instances of bar and automatically resolve its dependencies using it's Inject function.
    /// It is also possible to:
    /// - perform some custom logic after creation
    /// - manually override the Inject function, injecting dynamic dependencies at runtime.
    ///   (for example, when each instantiated behaviour needs a custom name or parent transform)
    /// </summary>
    public class BarFactoryBehaviour : UnifyBehaviour
    {
        private BarBehaviourFactory _factory;
        private int _numStrings = 0;

        [Inject]
        public void Inject(BarBehaviourFactory factory)
        {
            _factory = factory;
        }
        
        private void CreateAnInstanceOfBar()
        {
            _factory.Create(name: "An instantiated Bar"); // name is optional
        }
        
        private void CreateAnInstanceOfBarWithSomeCustomLogicBeforeItsStartFunction()
        {
            _factory.Create(
                afterInstantiationOverride: bar => Debug.Log($"A custom override action for {bar} just occurred before bar's start function."),
                name: "An instantiated Bar With a Custom Action"
            );
        }

        private void CreateAnInstanceOfBarWithAnOverrideInjection()
        {
            // Create a custom dependency override using the [FactoryOverride] method in `BarDependencyFactory` with id `withCustomString`
            var customParametersWeWantToPass = new object[] { $"someCustomString{_numStrings++}" };
            var customStringOverride = new DependencyOverride("withCustomString", customParametersWeWantToPass);
            
            _factory.Create(
                dependencyOverride: customStringOverride,
                name: "An instantiated Bar with a custom string parameter defined at runtime"
            );
        }

        private void OnGUI()
        {
            if (Selection.activeGameObject != this.gameObject) return;
            
            if (GUILayout.Button("Create a new Bar from the factory"))
                CreateAnInstanceOfBar();
            if (GUILayout.Button("Create a new Bar from Factory with a custom action override")) 
                CreateAnInstanceOfBarWithSomeCustomLogicBeforeItsStartFunction();
            if (GUILayout.Button("Create a new Bar from Factory with custom parameter override")) 
                CreateAnInstanceOfBarWithAnOverrideInjection();
        }
        

    }
}