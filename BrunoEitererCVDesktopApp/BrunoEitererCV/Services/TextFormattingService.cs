using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Markup;

namespace BrunoEitererCV.Services
{
    public static class TextFormattingService
    {
        public static Span FormatText(string input) => 
            (Span)XamlReader.Load($"<Span xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">{input}</Span>");
    }
}
