
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace OOPFoundation
{
    public class Text : ISanitization, ITextValidation
    {
        private readonly string _Text;
        private readonly string _ValidPattern;

        public Text(string text, string validPattern)
        {
            if (!TextIsValid(textToValidate: validPattern))
            {
                throw new ArgumentException($"Invalid argument 'validPattern'='{validPattern}' !");
            }
            _ValidPattern = validPattern;

            string sanitizedText = Sanitize(textToSanitize: text);
            if (!TextIsValid(textToValidate: sanitizedText))
            {
                throw new ArgumentException($"Invalid argument 'text'='{text}' !");
            }
            _Text = sanitizedText;
        }

        public string Sanitize(string textToSanitize)
        {
            string sanitizedText = System.String.Empty;
            try
            {
                sanitizedText = Regex.Replace(textToSanitize, @$"[^{_ValidPattern}]", string.Empty).Trim();
            }
            catch (ArgumentException)
            {
                throw new ArgumentException($"Pattern 'pattern'='{_ValidPattern}' inválido!");
            }

            return sanitizedText;
        }

        public bool TextIsValid(string textToValidate)
        {
            if (string.IsNullOrEmpty(textToValidate) ||
                string.IsNullOrWhiteSpace(textToValidate))
            {
                return false;
            }

            return true;
        }

        public string GetText()
        {
            return _Text;
        }

        public string ObtainHashedText()
        {
            return Convert.ToHexString(Hash()); 
        }
        private byte[] Hash()
        {
            return SHA256.HashData(Encode());

        }
        private byte[] Encode()
        {
            return Encoding.UTF8.GetBytes(_Text);

        }
    }
}
