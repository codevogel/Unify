using Unify.Core;
using UnityEditor;
using UnityEngine;

namespace Unify.Example.Behaviours
{
    /// <summary>
    /// The BazBehaviour is an example UnifyBehaviour that implements the example IBaz interface.
    /// </summary>
    public class BazBehaviour : UnifyBehaviour, IBaz
    {
        public void DoSomethingOnAnInterface()
        {
            Debug.Log($"Doing something on BazBehaviour with name {gameObject.name}!");
        }
        
        private void OnGUI()
        {
            if (Selection.activeGameObject != this.gameObject) return;
            
            if (GUILayout.Button("Call DoSomethingOnAnInterface on this BazBehaviour"))
                DoSomethingOnAnInterface();
        }
    }
}