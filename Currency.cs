
namespace OOPFoundation
{
    public class Currency: ADecimalValidation
    {
        private readonly decimal _Currency;
        private readonly Acronym ISOCode;

        public Currency(decimal currency, Acronym isoCode, 
                        decimal lowerLimit = 0.0M, 
                        decimal upperLimit= 0.0M): 
                base(lowerLimit, upperLimit)
        {
            ISOCode = isoCode ?? throw new ArgumentNullException(nameof(isoCode));

            if (LowerLimit < 0.0M) //Should it accept negative values?
            {
                throw new ArgumentException($"Invalid Argument 'lowerLimit'={lowerLimit}!");
            }
            if (UpperLimit < LowerLimit)
            {
                throw new ArgumentException($"Invalid Argument 'upperLimit'={upperLimit}!");
            }

            base.LowerLimit = lowerLimit;
            base.UpperLimit = upperLimit;

            if (!base.DecimalIsValid(currency))
            {
                throw new ArgumentException($"Invalid Argument 'currency'={currency} MUST BE [${lowerLimit}, ${upperLimit}]!");
            }

            _Currency = currency;
        }

        public decimal GetCurrency()
        {
            return _Currency;
        }
    }
}
