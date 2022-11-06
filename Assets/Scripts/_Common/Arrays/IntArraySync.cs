using UnityEngine.Events;

namespace KusogeKenkyuubu.Common
{
    [UnityEngine.CreateAssetMenu(fileName = "IntArraySync", menuName = "Arrays/Sync/IntArraySync")]
    public class IntArraySync : IntArray
    {
        public UnityEvent ArrayChanged;

        public override int[] Array
        {
            get => _array;
            set
            {
                _array = value;
                ArrayChanged.Invoke();
            }
        }

        public override int this[int index]
        {
            get => _array[index];
            set
            {
                int oldValue = _array[index];
                _array[index] = value;
                if (oldValue != value)
                    ArrayChanged.Invoke();
            }
        }
    }
}
