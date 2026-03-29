namespace OOPFoundation
{
    public class Acronym : AText
    {
        private readonly int NameLength;
        public Acronym(string text, 
            string validPattern=SanitizationPattern.UPPER_LETTERS_ONLY, 
            int nameLength=2) : base(text, validPattern)
        {
            if (nameLength < 0 ||
               nameLength > 10)
            {
                throw new ArgumentOutOfRangeException($"Invalid argument 'nameLength'='{nameLength}'!");
            }

            NameLength = nameLength;

            if (Text.Length != NameLength)
            {
                throw new ArgumentException($"Invalid argument 'text'='{text}'!");
            }
        }
        public string GetAcronym()
        {
            return Text.ToUpper();
        }
    }
}
