
namespace POOFoundation
{
    public class Year: IIntegerValidation
    {
        private readonly int _Year;
        private readonly int LowerLimit;
        private readonly int UpperLimit;

        public Year(int year, int lowerLimit = 0, int upperLimit= 0)
        {
            if (upperLimit == 0)
            {
                upperLimit = DateTime.Now.Year;
            }
            if (lowerLimit == 0)
            {
                lowerLimit = upperLimit - 100; // maximum of 100 years back
            }

            if (lowerLimit < 0)
            {
                throw new ArgumentException($"Invalid Argument 'lowerLimit'={lowerLimit}!");
            }
            if (upperLimit < lowerLimit)
            {
                throw new ArgumentException($"Invalid Argument 'upperLimit'={upperLimit}!");
            }

            LowerLimit = lowerLimit;
            UpperLimit = upperLimit;

            if (!IntegerIsValid(integerToValidate: year))
            {
                throw new ArgumentException($"Invalid Argument 'year'={year} [{LowerLimit}-{UpperLimit}]!");
            }

            _Year = year;
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

        public int GetYear()
        {
            return _Year;
        }
    }
}
