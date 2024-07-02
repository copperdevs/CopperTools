using UnityEngine;

namespace CopperDevs.Tools.Utility
{
    // Personally I like keeping my extensions to one line
    public static class Extensions
    {
        public static Vector2 WithX(this Vector2 v, float x) => new(x, v.y);

        public static Vector2 WithY(this Vector2 v, float y) => new(v.x, y);

        public static Vector3 WithX(this Vector3 v, float x) => new(x, v.y, v.z);

        public static Vector3 WithY(this Vector3 v, float y) => new(v.x, y, v.z);

        public static Vector3 WithZ(this Vector3 v, float z) => new(v.x, v.y, z);

        public static bool IsWithin(this Vector3 point, Collider targetCollider) => targetCollider.bounds.Contains(point);

        public static void CopyToClipboard(this string textToCopy) => Util.CopyToClipboard(textToCopy);

        public static string ToTitleCase(this string toConvert) => Util.ConvertToTitleCase(toConvert);
    }
}