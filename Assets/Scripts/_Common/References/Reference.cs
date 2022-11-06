namespace KusogeKenkyuubu.Common
{
    [System.Serializable]
    public abstract class Reference<T>
    {
        public bool UseConstant = true;
        public T ConstantValue;

        public Reference() { }

        public Reference(T value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public abstract T Value { get; set; }

        public static implicit operator T(Reference<T> reference) => reference.Value;
    }
}
