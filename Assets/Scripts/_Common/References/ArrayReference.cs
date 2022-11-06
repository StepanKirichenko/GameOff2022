using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KusogeKenkyuubu.Common
{
    [System.Serializable]
    public abstract class ArrayReference<T>
    {
        public bool UseConstant = true;
        public T[] ConstantValue;

        public ArrayReference() { }

        public ArrayReference(T[] value)
        {
            UseConstant = true;
            ConstantValue = value;
        }
        
        public abstract T[] Value { get; set; }

        public static implicit operator T[](ArrayReference<T> reference) => reference.Value;
        
        public abstract T this[int index] { get; set; }
    }
}
