using UnityEngine.Events;

namespace KusogeKenkyuubu.Common
{
    [UnityEngine.CreateAssetMenu(fileName = "BoolArraySync", menuName = "Arrays/Sync/BoolArraySync")]
    public class BoolArraySync : BoolArray
    {
        public UnityEvent ArrayChanged;

        public override bool[] Array
        {
            get => _array;
            set
            {
                _array = value;
                ArrayChanged.Invoke();
            }
        }

        public override bool this[int index]
        {
            get => _array[index];
            set
            {
                bool oldValue = _array[index];
                _array[index] = value;
                if (oldValue != value)
                    ArrayChanged.Invoke();
            }
        }
    }
}