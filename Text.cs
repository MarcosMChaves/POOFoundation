
namespace OOPFoundation
{
    public class Text : AText
    {
        public Text(string? text, string validPattern = SanitizationPattern.TEXT, bool isOptional = false) : 
                base(text, validPattern, isOptional)
        {
        }
    }
}
