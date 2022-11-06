namespace KusogeKenkyuubu.Common
{
    [System.Serializable]
    public class IntArrayReference : ArrayReference<int>
    {
        public IntArray Variable;

        public override int this[int index]
        {
            get => UseConstant ? ConstantValue[index] : Variable[index];
            set
            {
                if (UseConstant)
                    ConstantValue[index] = value;
                else
                    Variable[index] = value;
            }
        }

        public override int[] Value
        {
            get => UseConstant ? ConstantValue : Variable.Array;
            set
            {
                if (UseConstant)
                    ConstantValue = value;
                else
                    Variable.Array = value;
            }
        }
    }
}
