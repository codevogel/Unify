using Unify.Core;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Unify.Example.Behaviours
{
    /// <summary>
    /// The FooBehaviour is the simplest example of a UnifyBehaviour: it has no dependencies.
    /// </summary>
    public class FooBehaviour : UnifyBehaviour
    {
        public void DoSomething()
        {
            Debug.Log($"FooBehaviour just did something from gameObject with name {gameObject.name}");
        }

        private void OnGUI()
        {
            if (Selection.activeGameObject != this.GameObject()) return;
            
            if (GUILayout.Button("Call DoSomething on this FooBehaviour"))
                DoSomething();
        }
    }
}