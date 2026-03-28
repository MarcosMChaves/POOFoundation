
namespace OOPFoundation
{
    public class Year: AIntegerValidation
    {
        private readonly int _Year;

        public Year(int year, int lowerLimit = 0, int upperLimit= 0): base(lowerLimit, upperLimit)
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
            if (upperLimit < LowerLimit)
            {
                throw new ArgumentException($"Invalid Argument 'upperLimit'={upperLimit}!");
            }

            base.LowerLimit = lowerLimit;
            base.UpperLimit = upperLimit;

            if (!base.IntegerIsValid(year))
            {
                throw new ArgumentException($"Invalid Argument 'year'={year} MUST BE [{lowerLimit}, {upperLimit}]!");
            }

            _Year = year;
        }

        public int GetYear()
        {
            return _Year;
        }
    }
}
