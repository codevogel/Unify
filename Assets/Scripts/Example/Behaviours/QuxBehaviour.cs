using Plugins.Unify.Core;
using Plugins.Unify.Core.Attributes;
using UnityEditor;
using UnityEngine;

namespace Example.Behaviours
{
    /// <summary>
    /// The QuxBehaviour is an example UnifyBehaviour that depends on an implementation of IBaz.
    /// </summary>
    public class QuxBehaviour : UnifyBehaviour
    {
        private IBaz _bazThroughInterface;

        [Inject]
        public void Inject(IBaz baz)
        {
            _bazThroughInterface = baz;
        }

        private void OnGUI()
        {
            if (Selection.activeGameObject != this.gameObject) return;
            
            if (GUILayout.Button("Do something with the IBaz this QuxBehaviour depends on"))
                DoSomething();
        }

        private void DoSomething()
        {
            Debug.Log($"DoSomething just happened on QuxBehaviour with name {gameObject.name}");
            _bazThroughInterface.DoSomethingOnAnInterface();
        }
    }
}