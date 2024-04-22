using UnityEngine;

namespace CopperTools.Attributes
{
    public class MinMaxSliderAttribute : PropertyAttribute
    {
        public readonly float Minimum;
        public readonly float Maximum;

        public MinMaxSliderAttribute(float minimum, float maximum)
        {
            Minimum = minimum;
            Maximum = maximum;
        }
    }
}