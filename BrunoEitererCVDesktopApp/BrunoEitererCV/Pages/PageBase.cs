
using System;
using System.Collections.Generic;
using System.Linq;
using BrunoEitererCV.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Documents;
using Windows.Foundation;

namespace BrunoEitererCV.Pages;

public abstract class PageBase : Page
{
    protected LocalizationService LocalizationService { get; set; }
    protected PageBase()
    {
        LocalizationService = (Application.Current as App)?.ServiceProvider.GetRequiredService<LocalizationService>() ??
            throw new InvalidOperationException("Could not get a reference to the Localization Service");
    }

    protected void RefreshInlines(TextBlock textblock, string key, List<TypedEventHandler<Hyperlink, HyperlinkClickEventArgs>>? hyperlinkClicks = null)
    {
        hyperlinkClicks ??= [];

        textblock.Inlines.Clear();
        var formattedText = TextFormattingService.FormatText(LocalizationService[key]);

        foreach (var (hyperlink, hyperlinkClick) in formattedText.Inlines.OfType<Hyperlink>().Where(hl => hl.NavigateUri == null).Zip(hyperlinkClicks))
        {
            hyperlink.Click += hyperlinkClick;
        }

        textblock.Inlines.Add(formattedText);
    }
}
