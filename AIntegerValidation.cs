
namespace OOPFoundation
{
    public abstract class AIntegerValidation : IIntegerValidation
    {
        protected int LowerLimit;
        protected int UpperLimit;

        public AIntegerValidation(int lowerLimit, int upperLimit)
        {
            LowerLimit = lowerLimit;
            UpperLimit = upperLimit;
        }

        public bool IntegerIsValid(int integerToValidate)
        {
            if (integerToValidate < LowerLimit ||
                integerToValidate > UpperLimit)
            {
                return false;
            }

            return true;
        }
    }
}
