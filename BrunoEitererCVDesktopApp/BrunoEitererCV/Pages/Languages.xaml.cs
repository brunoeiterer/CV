using System.ComponentModel;
using BrunoEitererCV.Services;

namespace BrunoEitererCV.Pages;

public sealed partial class Languages : PageBase
{
    public Languages()
    {
        this.InitializeComponent();

        LocalizationService.PropertyChanged += OnLanguageChanged;

        PopulateText();
    }

    private void OnLanguageChanged(object? sender, PropertyChangedEventArgs e) => PopulateText();

    private void PopulateText()
    {
        RefreshInlines(EnglishTitleTextBlock, "English/Title");
        RefreshInlines(EnglishLevelTextBlock, "English/Level");
        RefreshInlines(EnglishTextBlock, "English/Text");
        RefreshInlines(PortugueseTitleTextBlock, "Portuguese/Title");
        RefreshInlines(PortugueseLevelTextBlock, "Portuguese/Level");
        RefreshInlines(FrenchTitleTextBlock, "French/Title");
        RefreshInlines(FrenchLevelTextBlock, "French/Level");
        RefreshInlines(FrenchTextBlock, "French/Text");
    }
}
