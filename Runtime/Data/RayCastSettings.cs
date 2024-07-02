using UnityEngine;

namespace CopperDevs.Tools.Data
{
    [System.Serializable]
    public class RayCastSettings
    {
        [SerializeField] private Transform rayOrigin;
        [SerializeField] private float maxDistance;
        [SerializeField] private LayerMask layer;

        public float MaxDistance
        {
            get => maxDistance;
            set => maxDistance = value;
        }

        public Transform RayOrigin
        {
            get => rayOrigin;
            set => rayOrigin = value;
        }

        public void RayCast(out bool hit, out RaycastHit rayCastHit)
        {
            hit = Physics.Raycast(rayOrigin.position, rayOrigin.forward, out rayCastHit, maxDistance, layer);
        }

        public bool RayCast(out RaycastHit hit)
        {
            return Physics.Raycast(rayOrigin.position, rayOrigin.forward, out hit, maxDistance, layer);
        }

        public Vector3 RayCast()
        {
            RayCast(out _, out var rayCastHit);
            return rayCastHit.point;
        }

        public bool IsHit() => RayCast(out _);

        public static implicit operator bool(RayCastSettings settings) => settings.RayCast(out _);

        public static implicit operator RaycastHit(RayCastSettings settings)
        {
            settings.RayCast(out var hit, out var rayCastHit);
            return rayCastHit;
        }

        public static implicit operator Vector3(RayCastSettings settings) => settings.RayCast();
    }
}