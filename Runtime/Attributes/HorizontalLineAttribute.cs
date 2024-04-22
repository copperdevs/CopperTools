using UnityEngine;

namespace CopperTools.Attributes
{
    public class HorizontalLineAttribute : PropertyAttribute
    {
        public readonly float Thickness;
        public readonly float Padding;

        public HorizontalLineAttribute(float thickness = 1f, float padding = 0f)
        {
            Thickness = thickness;
            Padding = padding;
        }
    }
}