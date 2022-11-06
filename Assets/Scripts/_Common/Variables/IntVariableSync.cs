using UnityEngine;
using UnityEngine.Events;

namespace KusogeKenkyuubu.Common
{
    [CreateAssetMenu(fileName = "IntVariableSync", menuName = "Variables/Sync/IntVariableSync")]
    public class IntVariableSync : IntVariable
    {
        public UnityEvent ValueChanged;
        
        public override int Value
        {
            get => _value;
            set
            {
                int oldValue = _value;
                _value = value;
                if (oldValue != _value)
                    ValueChanged.Invoke();
            }
        }
    }
}

