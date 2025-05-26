using System.ComponentModel;

namespace BrunoEitererCV.Pages;

public sealed partial class Skills : PageBase
{
    public Skills()
    {
        this.InitializeComponent();

        LocalizationService.PropertyChanged += OnLanguageChanged;

        PopulateText();
    }

    private void OnLanguageChanged(object? sender, PropertyChangedEventArgs e) => PopulateText();

    private void PopulateText()
    {
        RefreshInlines(GitYearsOfExperienceTextBlock, "Git/YearsOfExperience");
        RefreshInlines(GitTextBlock, "Git/Text");
        RefreshInlines(GithubCopilotYearsOfExperienceTextBlock, "GithubCopilot/YearsOfExperience");
        RefreshInlines(GithubCopilotTextBlock, "GithubCopilot/Text");
        RefreshInlines(ChatGPTYearsOfExperienceTextBlock, "ChatGPT/YearsOfExperience");
        RefreshInlines(ChatGPTTextBlock, "ChatGPT/Text");
        RefreshInlines(TeamCityYearsOfExperienceTextBlock, "TeamCity/YearsOfExperience");
        RefreshInlines(TeamCityTextBlock, "TeamCity/Text");
        RefreshInlines(MakeYearsOfExperienceTextBlock, "Make/YearsOfExperience");
        RefreshInlines(MakeTextBlock, "Make/Text");
        RefreshInlines(ScrumYearsOfExperience, "Scrum/YearsOfExperience");
        RefreshInlines(ScrumTextBlock, "Scrum/Text");
        RefreshInlines(JiraAndConfluenceYearsOfExperienceTextBlock, "JiraAndConfluence/YearsOfExperience");
        RefreshInlines(JiraAndConfluenceTextBlock, "JiraAndConfluence/Text");
        RefreshInlines(MSOfficeYearsOfExperienceTextBlock, "MSOffice/YearsOfExperience");
        RefreshInlines(MSOfficeTextBlock, "MSOffice/Text");
    }
}
