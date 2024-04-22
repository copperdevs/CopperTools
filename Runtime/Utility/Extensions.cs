using UnityEngine;

namespace CopperTools.Utility
{
    public static class Extensions
    {
        public static Vector2 WithX(this Vector2 v, float x)
        {
            return new Vector2(x, v.y);
        }

        public static Vector2 WithY(this Vector2 v, float y)
        {
            return new Vector2(v.x, y);
        }

        public static Vector3 WithX(this Vector3 v, float x)
        {
            return new Vector3(x, v.y, v.z);
        }

        public static Vector3 WithY(this Vector3 v, float y)
        {
            return new Vector3(v.x, y, v.z);
        }

        public static Vector3 WithZ(this Vector3 v, float z)
        {
            return new Vector3(v.x, v.y, z);
        }
        
        public static bool IsWithin(this Vector3 point, Collider targetCollider)
        {
            return targetCollider.bounds.Contains(point);
        }
        
        public static void CopyToClipboard(this string textToCopy)
        {
            Util.CopyToClipboard(textToCopy);
        }

        public static string ToTitleCase(this string toConvert)
        {
            return Util.ConvertToTitleCase(toConvert);
        }
    }
}