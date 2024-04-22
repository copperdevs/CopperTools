using UnityEngine;

namespace CopperTools.Utility
{
    public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

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
    }
}