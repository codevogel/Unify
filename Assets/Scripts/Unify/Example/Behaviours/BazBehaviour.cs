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
            Debug.Log("DoSomethingOnAnInterface just happened on BazBehaviour");
        }
        
        private void OnGUI()
        {
            if (Selection.activeGameObject != this.GameObject()) return;
            
            if (GUILayout.Button("Call DoSomethingOnAnInterface on this BazBehaviour"))
                DoSomethingOnAnInterface();
        }
    }
}