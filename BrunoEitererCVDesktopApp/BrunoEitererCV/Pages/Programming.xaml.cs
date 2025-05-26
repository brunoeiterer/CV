using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Documents;
using System;
using BrunoEitererCV.Services;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace BrunoEitererCV.Pages;

public sealed partial class Programming : PageBase
{
    private readonly NavigationService NavigationService;
    public Programming()
    {
        this.InitializeComponent();
        NavigationService = (Application.Current as App)?.ServiceProvider.GetRequiredService<NavigationService>() ?? 
            throw new InvalidOperationException("Could not get a reference to the Navigation Service");

        PopulateText();

        LocalizationService.PropertyChanged += OnLanguageChanged;
    }

    public void OnSideProjectsHyperlinkClick(Hyperlink sender, HyperlinkClickEventArgs e) =>
        NavigationService.Navigate(typeof(SideProjects));

    private void OnLanguageChanged(object? sender, PropertyChangedEventArgs e) => PopulateText();

    private void PopulateText()
    {
        RefreshInlines(CSharpYearsOfExperienceTextBlock, "CSharp/YearsOfExperience");
        RefreshInlines(CsharpTextBlock, "CSharp/Text", [OnSideProjectsHyperlinkClick]);
        RefreshInlines(CYearsOfExperienceTextBlock, "C/YearsOfExperience");
        RefreshInlines(CTextBlock, "C/Text");
        RefreshInlines(CppYearsOfExperienceTextBlock, "Cpp/YearsOfExperience");
        RefreshInlines(CppTextBlock, "Cpp/Text");
        RefreshInlines(PythonYearsOfExperienceTextBlock, "Python/YearsOfExperience");
        RefreshInlines(PythonTextBlock, "Python/Text");
        RefreshInlines(JavascriptYearsOfExperienceTextBlock, "Javascript/YearsOfExperience");
        RefreshInlines(JavascriptTextBlock, "Javascript/Text");
        RefreshInlines(TypescriptYearsOfExperienceTextBlock, "Typescript/YearsOfExperience");
        RefreshInlines(TypescriptTextBlock, "Typescript/Text", [OnSideProjectsHyperlinkClick]);
        RefreshInlines(JavaYearsOfExperienceTextBlock, "Java/YearsOfExperience");
        RefreshInlines(JavaTextBlock, "Java/Text");
    }
}
