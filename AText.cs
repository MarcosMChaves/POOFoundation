
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace OOPFoundation
{
    public abstract class AText : ISanitization, ITextValidation
    {
        protected readonly string Text;
        protected readonly string ValidPattern;

        public AText(string text, string validPattern)
        {
            if (!TextIsValid(textToValidate: validPattern))
            {
                throw new ArgumentException($"Invalid argument 'validPattern'='{validPattern}' !");
            }
            ValidPattern = validPattern;

            string sanitizedText = Sanitize(textToSanitize: text);
            if (!TextIsValid(textToValidate: sanitizedText))
            {
                throw new ArgumentException($"Invalid argument 'text'='{text}' !");
            }
            Text = sanitizedText;
        }

        public string Sanitize(string textToSanitize)
        {
            string sanitizedText = System.String.Empty;
            try
            {
                sanitizedText = Regex.Replace(textToSanitize, @$"[^{ValidPattern}]", string.Empty).Trim();
            }
            catch (ArgumentException)
            {
                throw new ArgumentException($"Pattern 'pattern'='{ValidPattern}' inválido!");
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
            return Encoding.UTF8.GetBytes(Text);

        }
    }
}
