using System.Collections;
using UnityEngine;

namespace CopperDevs.Tools.Scenes.Transitioner
{
    [CreateAssetMenu(fileName = "Circle", menuName = "Data/Scene Transitions/Circle")]
    public class CircleTransition : BaseTransition
    {
        [Header("Circle Transition Settings")]
        [SerializeField] private Sprite circleSprite;
        [SerializeField] private Color color;

        public override IEnumerator Enter(Canvas parent)
        {
            var time = 0f;
            var size = Mathf.Sqrt(Mathf.Pow(Screen.width, 2) + Mathf.Pow(Screen.height, 2));
            var initialSize = new Vector2(size, size);

            while (time < 1)
            {
                AnimatedObject.rectTransform.sizeDelta = Vector2.Lerp(initialSize, Vector2.zero, lerpCurve.Evaluate(time));
                yield return null;
                time += Time.deltaTime / animationTime;
            }

            Destroy(AnimatedObject.gameObject);
        }

        public override IEnumerator Exit(Canvas Parent)
        {
            AnimatedObject = CreateImage(Parent);
            AnimatedObject.color = color;
            AnimatedObject.rectTransform.sizeDelta = Vector2.zero;
            AnimatedObject.sprite = circleSprite;

            var time = 0f;
            var size = Mathf.Sqrt(Mathf.Pow(Screen.width, 2) + Mathf.Pow(Screen.height, 2));
            var targetSize = new Vector2(size, size);
            
            while (time < 1)
            {
                AnimatedObject.rectTransform.sizeDelta = Vector2.Lerp(Vector2.zero, targetSize, lerpCurve.Evaluate(time));
                yield return null;
                time += Time.deltaTime / animationTime;
            }
        }
    }
}