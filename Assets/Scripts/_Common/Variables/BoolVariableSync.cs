using UnityEngine;
using UnityEngine.Events;

namespace KusogeKenkyuubu.Common
{
    [CreateAssetMenu(fileName = "BoolVariableSync", menuName = "Variables/Sync/BoolVariableSync")]
    public class BoolVariableSync : BoolVariable
    {
        public UnityEvent ValueChanged;
        
        public override bool Value
        {
            get => _value;
            set
            {
                bool oldValue = _value;
                _value = value;
                if (oldValue != _value)
                    ValueChanged.Invoke();
            }
        }
    }
}
