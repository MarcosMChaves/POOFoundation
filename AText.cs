
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace OOPFoundation
{
    public abstract class AText : ISanitization, ITextValidation, IFormattable
    {
        protected string Text;
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

        public string GetText()
        {
            return Text;
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

        public string ToString(string? format, IFormatProvider? provider)
        {
            string validPattern = "\\#0\\/\\-\\s.";
            string sanitizedFormat = Regex.Replace(format, @$"[^{validPattern}]", string.Empty).Trim();
            if (!TextIsValid(textToValidate: sanitizedFormat))
            {
                throw new ArgumentException($"Invalid argument 'format'='{format}' !");
            }

            validPattern = "\\/\\-\\s.";
            string removedFormat = Regex.Replace(sanitizedFormat, @$"[{validPattern}]", string.Empty).Trim();
            if (Text.Length != removedFormat.Length)
            {
                throw new ArgumentException($"Invalid argument 'format'='{format}' does not match text!");
            }
            string stringFormatada = string.Empty;

            int j = 0;
            for (int i = 0; i < format.Length; i++)
            {
                if (format[i].Equals('0') ||
                    format[i].Equals('#'))
                {
                    stringFormatada += Text[j];
                    j++;
                }
                else
                {
                    stringFormatada += format[i];
                }
            }

            return stringFormatada;
        }

    }
}
