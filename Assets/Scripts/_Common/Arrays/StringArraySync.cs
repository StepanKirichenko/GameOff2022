using UnityEngine.Events;

namespace KusogeKenkyuubu.Common
{
    [UnityEngine.CreateAssetMenu(fileName = "StringArraySync", menuName = "Arrays/Sync/StringArraySync")]
    public class StringArraySync : StringArray
    {
        public UnityEvent ArrayChanged;

        public override string[] Array
        {
            get => _array;
            set
            {
                _array = value;
                ArrayChanged.Invoke();
            }
        }

        public override string this[int index]
        {
            get => _array[index];
            set
            {
                string oldValue = _array[index];
                _array[index] = value;
                if (oldValue != value)
                    ArrayChanged.Invoke();
            }
        }
    }
}