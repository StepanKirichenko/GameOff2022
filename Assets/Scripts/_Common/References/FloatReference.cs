namespace KusogeKenkyuubu.Common
{
    [System.Serializable]
    public class FloatReference : Reference<float>
    {
        public FloatVariable Variable;

        public override float Value
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

