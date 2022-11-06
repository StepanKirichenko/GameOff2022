using UnityEngine;

namespace KusogeKenkyuubu.Common
{
    public abstract class GenericArray<T> : ScriptableObject
    {
        [SerializeField] protected T[] _array;

        public virtual T[] Array
        {
            get => _array;
            set => _array = value;
        }
        
        public virtual T this[int index]
        {
            get => _array[index];
            set => _array[index] = value;
        }

        public int Length => _array.Length;
    }
}
