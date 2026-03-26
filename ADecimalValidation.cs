
namespace OOPFoundation
{
    public abstract class ADecimalValidation : IDecimalValidation
    {
        protected decimal LowerLimit;
        protected decimal UpperLimit;

        public ADecimalValidation(decimal lowerLimit, decimal upperLimit)
        {
            LowerLimit = lowerLimit;
            UpperLimit = upperLimit;
        }

        public bool DecimalIsValid(decimal decimalToValidate)
        {
            if (decimalToValidate < LowerLimit ||
                decimalToValidate > UpperLimit)
            {
                return false;
            }

            return true;
        }
    }
}
