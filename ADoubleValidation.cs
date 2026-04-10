
namespace OOPFoundation
{
    public abstract class ADoubleValidation : IDoubleValidation
    {
        protected double LowerLimit;
        protected double UpperLimit;

        public ADoubleValidation(double lowerLimit, double upperLimit)
        {
            LowerLimit = lowerLimit;
            UpperLimit = upperLimit;
        }

        public bool DoubleIsValid(double doubleToValidate)
        {
            if (doubleToValidate < LowerLimit ||
                doubleToValidate > UpperLimit)
            {
                return false;
            }

            return true;
        }
    }
}
