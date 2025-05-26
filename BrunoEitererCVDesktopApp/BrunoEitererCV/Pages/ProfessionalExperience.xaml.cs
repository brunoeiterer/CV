using System.ComponentModel;
using BrunoEitererCV.Services;

namespace BrunoEitererCV.Pages;

public sealed partial class ProfessionalExperience : PageBase
{
    public ProfessionalExperience()
    {
        this.InitializeComponent();
        LocalizationService.PropertyChanged += OnLanguageChanged;
        PopulateText();
    }

    private void OnLanguageChanged(object? sender, PropertyChangedEventArgs e) => PopulateText();

    private void PopulateText()
    {
        RefreshInlines(RDISeniorSoftwareDeveloperTitleTextBlock, "RDI/SeniorSoftwareDeveloper/Title");
        RefreshInlines(RDISeniorSoftwareDeveloperTextBlock, "RDI/SeniorSoftwareDeveloper/Text");
        RefreshInlines(RDISoftwareDevelopmentConsultantTitleTextBlock, "RDI/SoftwareDevelopmentConsultant/Title");
        RefreshInlines(RDISoftwareDevelopmentConsultantTextBlock, "RDI/SoftwareDevelopmentConsultant/Text");
        RefreshInlines(GertecMiddleSoftwareDeveloperTitleTextBlock, "Gertec/MiddleSoftwareDeveloper/Title");
        RefreshInlines(GertecMiddleSoftwareDeveloperTextBlock, "Gertec/MiddleSoftwareDeveloper/Text");
        RefreshInlines(GertecSoftwareDeveloperTitleTextBlock, "Gertec/SoftwareDeveloper/Title");
        RefreshInlines(GertecSoftwareDeveloperTextBlock, "Gertec/SoftwareDeveloper/Text");
        RefreshInlines(FreelanceSoftwareDeveloperTitle, "Freelance/SoftwareDeveloper/Title");
        RefreshInlines(FreelanceSoftwareDeveloperText, "Freelance/SoftwareDeveloper/Text");
        RefreshInlines(ASMLEmbeddedSoftwareInternTitleTextBlock, "ASML/EmbeddedSoftwareIntern/Title");
        RefreshInlines(ASMLEmbeddedSoftwareInternTextBlock, "ASML/EmbeddedSoftwareIntern/Text");
    }
}
