using UnityEngine;
using UnityEngine.Events;

namespace KusogeKenkyuubu.Common
{
    [CreateAssetMenu(fileName = "StringVariableSync", menuName = "Variables/Sync/StringVariableSync")]
    public class StringVariableSync : StringVariable
    {
        public UnityEvent ValueChanged;
        
        public override string Value
        {
            get => _value;
            set
            {
                string oldValue = _value;
                _value = value;
                if (oldValue != _value)
                    ValueChanged.Invoke();
            }
        }
    }
}

