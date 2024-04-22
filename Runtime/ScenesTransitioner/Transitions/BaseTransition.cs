using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CopperTools.ScenesTransitioner
{
    public abstract class BaseTransition : ScriptableObject
    {
        [Header("Base Transition Settings")]
        [SerializeField] protected AnimationCurve lerpCurve = new(new Keyframe(0, 0), new Keyframe(0.5f, 0.75f), new Keyframe(1, 1));

        [SerializeField] protected float animationTime = 0.25f;

        protected Image AnimatedObject;

        public abstract IEnumerator Enter(Canvas parent);
        public abstract IEnumerator Exit(Canvas parent);

        protected virtual Image CreateImage(Canvas parent)
        {
            var child = new GameObject("Transition Image");
            child.transform.SetParent(parent.transform, false);

            return child.AddComponent<Image>();
        }
    }
}