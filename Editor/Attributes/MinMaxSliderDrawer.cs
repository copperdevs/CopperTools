using CopperTools.Attributes;
using UnityEditor;
using UnityEngine;

namespace CopperTools.Editor.Attributes
{
    [CustomPropertyDrawer(typeof(MinMaxSliderAttribute))]
    public class MinMaxSliderDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var minMaxAttribute = (MinMaxSliderAttribute)attribute;
            var propertyType = property.propertyType;

            label.tooltip = minMaxAttribute.Minimum.ToString("F2") + " to " + minMaxAttribute.Maximum.ToString("F2");

            //PrefixLabel returns the rect of the right part of the control. It leaves out the label section. We don't have to worry about it. Nice!
            var controlRect = EditorGUI.PrefixLabel(position, label);
            var splittedRect = SplitRect(controlRect, 3);

            switch (propertyType)
            {
                case SerializedPropertyType.Vector2:
                {
                    EditorGUI.BeginChangeCheck();

                    var vector = property.vector2Value;
                    var minVal = vector.x;
                    var maxVal = vector.y;

                    //F2 limits the float to two decimal places (0.00).
                    minVal = EditorGUI.FloatField(splittedRect[0], float.Parse(minVal.ToString("F2")));
                    maxVal = EditorGUI.FloatField(splittedRect[2], float.Parse(maxVal.ToString("F2")));

                    EditorGUI.MinMaxSlider(splittedRect[1], ref minVal, ref maxVal, minMaxAttribute.Minimum, minMaxAttribute.Maximum);

                    if (minVal < minMaxAttribute.Minimum)
                        minVal = minMaxAttribute.Minimum;

                    if (maxVal > minMaxAttribute.Maximum)
                        maxVal = minMaxAttribute.Maximum;

                    vector = new Vector2(minVal > maxVal ? maxVal : minVal, maxVal);

                    if (EditorGUI.EndChangeCheck())
                        property.vector2Value = vector;

                    break;
                }
                case SerializedPropertyType.Vector2Int:
                {
                    EditorGUI.BeginChangeCheck();

                    var vector = property.vector2IntValue;
                    float minVal = vector.x;
                    float maxVal = vector.y;

                    minVal = EditorGUI.FloatField(splittedRect[0], minVal);
                    maxVal = EditorGUI.FloatField(splittedRect[2], maxVal);

                    EditorGUI.MinMaxSlider(splittedRect[1], ref minVal, ref maxVal,
                        minMaxAttribute.Minimum, minMaxAttribute.Maximum);

                    if (minVal < minMaxAttribute.Minimum) 
                        maxVal = minMaxAttribute.Minimum;

                    if (minVal > minMaxAttribute.Maximum) 
                        maxVal = minMaxAttribute.Maximum;

                    vector = new Vector2Int(Mathf.FloorToInt(minVal > maxVal ? maxVal : minVal), Mathf.FloorToInt(maxVal));

                    if (EditorGUI.EndChangeCheck()) 
                        property.vector2IntValue = vector;

                    break;
                }
            }
        }

        private static Rect[] SplitRect(Rect rectToSplit, int count)
        {
            var rects = new Rect[count];

            for (var i = 0; i < count; i++) 
                rects[i] = new Rect(rectToSplit.position.x + (i * rectToSplit.width / count), rectToSplit.position.y, rectToSplit.width / count, rectToSplit.height);

            var padding = (int)rects[0].width - 40;
            var space = 5;

            rects[0].width -= padding + space;
            rects[2].width -= padding + space;

            rects[1].x -= padding;
            rects[1].width += padding * 2;

            rects[2].x += padding + space;


            return rects;
        }
    }
}