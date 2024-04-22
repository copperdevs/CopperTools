using System;
using UnityEngine;

// https://gist.github.com/INeatFreak/e01763f844336792ebe07c1cd1b6d018

namespace CopperTools.Variables
{
    [Serializable]
    public struct Optional<T>
    {
        [SerializeField] private bool enabled;
        [SerializeField] private T value;

        public bool Enabled => enabled;
        public T Value => value;

        public Optional(T initialValue)
        {
            enabled = true;
            value = initialValue;
        }

        public Optional(T initialValue, bool enabled)
        {
            this.enabled = enabled;
            value = initialValue;
        }

        public static implicit operator Optional<T>(T v)
        {
            return new Optional<T>(v);
        }

        public static implicit operator T(Optional<T> o)
        {
            return o.Value;
        }

        public static implicit operator bool(Optional<T> o)
        {
            return o.enabled;
        }

        public static bool operator ==(Optional<T> lhs, Optional<T> rhs)
        {
            if (lhs.value is null)
                return rhs.value is null;
            return lhs.value.Equals(rhs.value);
        }

        public static bool operator !=(Optional<T> lhs, Optional<T> rhs)
        {
            return !(lhs == rhs);
        }

        public override bool Equals(object obj)
        {
            // return base.Equals(obj);
            return value.Equals(obj);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }


        public override string ToString() => value.ToString();
    }
}