using CopperDevs.Tools.Attributes;
using UnityEditor;
using UnityEngine;

namespace CopperDevs.Tools.Editor.Attributes
{
    [CustomPropertyDrawer(typeof(HorizontalLineAttribute))]
    public class HorizontalLineDrawer : DecoratorDrawer
    {
        public override float GetHeight()
        {
            var attr = attribute as HorizontalLineAttribute;
            return Mathf.Max(attr!.Padding, attr.Thickness);
        }

        public override void OnGUI(Rect position)
        {
            var attr = attribute as HorizontalLineAttribute;

            position.height = attr!.Thickness;
            position.y += attr.Padding * 0.5f;

            EditorGUI.DrawRect(position, EditorGUIUtility.isProSkin ? new Color(.4f, .4f, .4f, 1) : new Color(.7f, .7f, .7f, 1));
        }
    }
}