using Unify.Core;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Unify.Example.Behaviours
{
    public class BazBehaviour : UnifyBehaviour, IBaz
    {
        public void DoSomethingOnAnInterface()
        {
            Debug.Log($"Doing something on BazBehaviour with name {gameObject.name}!");
        }
        
        private void OnGUI()
        {
            if (Selection.activeGameObject != this.GameObject()) return;
            
            if (GUILayout.Button("Call DoSomethingOnAnInterface on this BazBehaviour"))
                DoSomethingOnAnInterface();
        }
    }
}