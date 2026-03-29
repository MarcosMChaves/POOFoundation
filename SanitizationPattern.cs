
namespace OOPFoundation
{
    public class SanitizationPattern
    {
        public const string CNPJ = "a-zA-Z0-9";
        public const string CPF = "0-9";
        public const string PHONE = "0-9";
        public const string RG = "0-9Xx";
        public const string ISBN = "0-9";
        public const string ISSN = "0-9Xx";
        public const string EMAIL = "0-9a-zA-Z\\.\\-\\_\\@";
        public const string COUNTRY = "(?!.*[ -]{2})\\p{L}[\\p{L} -]{1,58}\\p{L}";
        public const string STATE = "(?!.*[ -]{2})\\p{L}[\\p{L} -]{1,58}\\p{L}";
        public const string COUNTY = "(?!.*[ -]{2})\\p{L}[\\p{L} -]{1,58}\\p{L}";

        public const string UTF8 = "\\p{L}";
        public const string TEXT = "\\p{L}\\s.";
        public const string DIGITS_ONLY = "0-9";
        public const string DIGITS_LETTERS = "0-9a-zA-Z";
        public const string LETTERS_ONLY = "a-zA-Z";
        public const string UPPER_LETTERS_ONLY = "A-Z";
        public const string LOWER_LETTERS_ONLY = "a-z";
    }
}
