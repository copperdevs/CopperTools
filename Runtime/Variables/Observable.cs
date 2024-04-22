using System;
using UnityEngine;

// https://gist.github.com/vantreeseba/c19c2387bac86047f30d7bec1e41a824

namespace CopperTools.Variables
{
    [Serializable]
    public class Observable<T>
    {
        [SerializeField] private T value;

        public T Value
        {
            get => value;
            set
            {
                if (this.value.Equals(value))
                {
                    return;
                }

                this.value = value;
                OnChange?.Invoke(this.value);
            }
        }

        public event Action<T> OnChange;
        public static implicit operator T(Observable<T> obs) => obs.value;
        public override string ToString() => value.ToString();
    }
}