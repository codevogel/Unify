using Unify.Core;
using Unify.Core.Attributes;
using Unify.Example.Factories;
using UnityEngine;

namespace Unify.Example.Behaviours
{
    /// <summary>
    /// A UnifyBehaviour that creates BarBehaviours using a factory.
    /// </summary>
    public class BehaviourWithBarFactory : UnifyBehaviour
    {
        private BarDependencyFactory _factory;
        private int _numStrings = 0;

        [Inject]
        public void Inject(BarDependencyFactory factory)
        {
            _factory = factory;
        }

        void OnGUI()
        {
            if (GUILayout.Button("Create Bar from Factory"))
                _factory.Create("An instantiated Bar");
            if (GUILayout.Button("Create Bar from Factory with custom action override"))
                _factory.Create(
                    bar => Debug.Log($"A custom override action for {bar} just occurred before bar's start function."),
                    "An instantiated Bar With a Custom Action"
                    );
            if (GUILayout.Button("Create Bar from Factory with custom parameter override"))
                _factory.Create(
                    "An instantiated Bar with a custom string parameter defined at runtime",
                    new DependencyOverride("withCustomString",new object[]{ $"someCustomString{_numStrings++}"}));
        }
    }
}