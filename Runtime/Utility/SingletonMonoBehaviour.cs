using UnityEngine;

namespace CopperDevs.Tools.Utility
{
    public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        // ReSharper disable once InconsistentNaming
        public static T Instance
        {
            get
            {
                if (instance != null)
                    return instance;

                instance = (T)FindFirstObjectByType(typeof(T));

                if (instance == null)
                    instance = new GameObject(typeof(T).ToString()).AddComponent<T>();

                return instance;
            }
        }
        
        public static bool TryGetInstance(out T result)
        {
            result = instance;
            return instance == null;
        }
    }
}
