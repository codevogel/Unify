using System;
using Unify.Core;
using Unify.Core.Attributes;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Unify.Example.Behaviours
{
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
            if (Selection.activeGameObject != this.GameObject()) return;
            
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