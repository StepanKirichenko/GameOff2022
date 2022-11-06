namespace KusogeKenkyuubu.Common
{
    [System.Serializable]
    public class IntReference : Reference<int>
    {
        public IntVariable Variable;

        public override int Value
        {
            get => UseConstant ? ConstantValue : Variable.Value;
            set
            {
                if (UseConstant)
                    ConstantValue = value;
                else
                    Variable.Value = value;
            }
        }
    }
}
