using UnityEngine;

namespace CopperTools.Variables
{
    public class ValueObject<T> : ScriptableObject
    {
        public T value;

        public override string ToString() => JsonUtility.ToJson(value);

        public static implicit operator T(ValueObject<T> valueObject) => valueObject.value;
    }
}