using System.ComponentModel;

namespace BrunoEitererCV.Pages;

public sealed partial class Education : PageBase
{
    public Education()
    {
        this.InitializeComponent();

        LocalizationService.PropertyChanged += OnLanguageChanged;
        PopulateText();
    }

    private void OnLanguageChanged(object? sender, PropertyChangedEventArgs e) => PopulateText();

    private void PopulateText()
    {
        ElectricalEngineeringExpander.Header = LocalizationService["ElectricalEngineering/Title"];
        RefreshInlines(UFSCTitleTextBlock, "UFSC/Title");
        RefreshInlines(UFSCTextBlock, "UFSC/Text");
    }
}
