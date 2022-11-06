using UnityEngine;

namespace KusogeKenkyuubu.Common
{
    public abstract class Variable<T> : ScriptableObject
    {
        [SerializeField] protected T _value;
        [SerializeField] private bool _isPersistentBetweenScenes;
        
        public virtual T Value
        {
            get => _value;
            set => _value = value;
        }

        public static implicit operator T(Variable<T> v) => v.Value;
        
        private void OnEnable()
        {
            if (_isPersistentBetweenScenes)
                hideFlags = HideFlags.DontUnloadUnusedAsset;
        }
    }
}
