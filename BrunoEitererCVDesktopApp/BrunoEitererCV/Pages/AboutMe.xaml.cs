using System;
using System.ComponentModel;
using BrunoEitererCV.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;

namespace BrunoEitererCV.Pages;

public sealed partial class AboutMe : PageBase
{
    private readonly NavigationService _navigationService;

    public AboutMe()
    {
        this.InitializeComponent();
        _navigationService = (Application.Current as App)?.ServiceProvider.GetRequiredService<NavigationService>() ??
            throw new InvalidOperationException("Could not get a reference to the Navigation Service");

        LocalizationService.PropertyChanged += OnLanguageChanged;

        PopulateText();
    }

    public void OnSideProjectsHyperlinkClick(object sender, RoutedEventArgs e) => _navigationService.Navigate(typeof(SideProjects));

    private void OnLanguageChanged(object? sender, PropertyChangedEventArgs e) => PopulateText();

    private void PopulateText()
    {
        GreetingTextBlock.Text = LocalizationService["AboutMe/Greeting"];
        RefreshInlines(BodyTextBlock, "AboutMe/Text", [OnSideProjectsHyperlinkClick]);
    }
}
