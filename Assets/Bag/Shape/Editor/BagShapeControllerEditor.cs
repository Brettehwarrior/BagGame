using UnityEditor;
using UnityEngine;

namespace Bag.Shape.Editor
{
    [CustomEditor(typeof(BagShapeController))]
    public class BagShapeControllerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            BagShapeController bagShapeController = (BagShapeController)target;

            if (GUILayout.Button("Snap to Target"))
            {
                bagShapeController.SnapToTargets();
            }
            
            DrawDefaultInspector();
        }
    }
}