using CopperTools.Attributes;
using UnityEditor;
using UnityEngine;

namespace CopperTools.Editor.Attributes
{
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class ReadOnlyPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            using (new EditorGUI.DisabledScope())
            {
                EditorGUI.PropertyField(position, property, label);
            }
        }
    }
}