namespace KusogeKenkyuubu.Common
{
    [System.Serializable]
    public class StringReference : Reference<string>
    {
        public StringVariable Variable;

        public override string Value
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

