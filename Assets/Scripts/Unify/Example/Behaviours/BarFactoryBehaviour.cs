using Unify.Core;
using Unify.Core.Attributes;
using Unify.Example.Factories;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Unify.Example.Behaviours
{
    /// <summary>
    /// A UnifyBehaviour that creates BarBehaviours using a factory.
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
            _factory.Create(name: "An instantiated Bar");
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

        void OnGUI()
        {
            if (Selection.activeGameObject != this.GameObject()) return;
            
            if (GUILayout.Button("Create a new Bar from the factory"))
                CreateAnInstanceOfBar();
            if (GUILayout.Button("Create a new Bar from Factory with a custom action override")) 
                CreateAnInstanceOfBarWithSomeCustomLogicBeforeItsStartFunction();
            if (GUILayout.Button("Create a new Bar from Factory with custom parameter override")) 
                CreateAnInstanceOfBarWithAnOverrideInjection();
        }
        

    }
}