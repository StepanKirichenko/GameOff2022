using UnityEngine;
using UnityEngine.Events;

namespace KusogeKenkyuubu.Common
{
    [CreateAssetMenu(fileName = "FloatVariableSync", menuName = "Variables/Sync/FloatVariableSync")]
    public class FloatVariableSync : FloatVariable
    {
        public UnityEvent ValueChanged;
        
        public override float Value
        {
            get => _value;
            set
            {
                float oldValue = _value;
                _value = value;
                if (oldValue != _value)
                    ValueChanged.Invoke();
            }
        }
    }
}

