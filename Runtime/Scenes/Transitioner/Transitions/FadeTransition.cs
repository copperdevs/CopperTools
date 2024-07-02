using System.Collections;
using UnityEngine;

namespace CopperDevs.Tools.Scenes.Transitioner
{
    [CreateAssetMenu(fileName = "Fade", menuName = "Data/Scene Transitions/Fade")]
    public class FadeTransition : BaseTransition
    {
        public override IEnumerator Enter(Canvas parent)
        {
            float time = 0;
            var startColor = Color.black;
            var endColor = new Color(0, 0, 0, 0);
            while (time < 1)
            {
                AnimatedObject.color = Color.Lerp(
                    startColor,
                    endColor,
                    lerpCurve.Evaluate(time)
                );
                yield return null;
                time += Time.deltaTime / animationTime;
            }

            Destroy(AnimatedObject.gameObject);
        }

        public override IEnumerator Exit(Canvas parent)
        {
            AnimatedObject = CreateImage(parent);
            AnimatedObject.rectTransform.anchorMin = Vector2.zero;
            AnimatedObject.rectTransform.anchorMax = Vector2.one;
            AnimatedObject.rectTransform.sizeDelta = Vector2.zero;

            float time = 0;
            var startColor = new Color(0, 0, 0, 0);
            var endColor = Color.black;
            while (time < 1)
            {
                AnimatedObject.color = Color.Lerp(
                    startColor,
                    endColor,
                    lerpCurve.Evaluate(time)
                );
                yield return null;
                time += Time.deltaTime / animationTime;
            }
        }
    }
}