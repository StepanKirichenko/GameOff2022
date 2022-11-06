namespace KusogeKenkyuubu.Common
{
    [System.Serializable]
    public class BoolReference : Reference<bool>
    {
        public BoolVariable Variable;

        public override bool Value
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

