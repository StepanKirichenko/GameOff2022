using UnityEngine.Events;

namespace KusogeKenkyuubu.Common
{
    [UnityEngine.CreateAssetMenu(fileName = "FloatArraySync", menuName = "Arrays/Sync/FloatArraySync")]
    public class FloatArraySync : FloatArray
    {
        public UnityEvent ArrayChanged;

        public override float[] Array
        {
            get => _array;
            set
            {
                _array = value;
                ArrayChanged.Invoke();
            }
        }

        public override float this[int index]
        {
            get => _array[index];
            set
            {
                float oldValue = _array[index];
                _array[index] = value;
                if (oldValue != value)
                    ArrayChanged.Invoke();
            }
        }
    }
}