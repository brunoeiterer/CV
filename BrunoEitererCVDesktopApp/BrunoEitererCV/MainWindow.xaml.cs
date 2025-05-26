using System;
using System.ComponentModel;
using BrunoEitererCV.Pages;
using BrunoEitererCV.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using WinRT.Interop;

namespace BrunoEitererCV;

public sealed partial class MainWindow : Window
{
    public NavigationView NavigationView => MainNavigationView;
    private readonly LocalizationService _localizationService;

    public MainWindow()
    {
        this.InitializeComponent();
        ((OverlappedPresenter)AppWindow.Presenter).Maximize();

        if (AppWindowTitleBar.IsCustomizationSupported() is true)
        {
            var hWnd = WindowNative.GetWindowHandle(this);
            var wndId = Win32Interop.GetWindowIdFromWindow(hWnd);
            var appWindow = AppWindow.GetFromWindowId(wndId);
            appWindow.SetIcon(@"Assets\Logo.ico");
        }

        _localizationService = (Application.Current as App)?.ServiceProvider.GetRequiredService<LocalizationService>() ??
            throw new InvalidOperationException("Could not get a reference to the Localization Service");
        _localizationService.PropertyChanged += OnLanguageChanged;

        LanguageCombobox.SelectedIndex = 0;
    }

    public void OnNavigationViewSelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
    {
        if (args.SelectedItem is not NavigationViewItem navigationViewItem)
        {
            return;
        }

        var pageType = navigationViewItem.Name switch
        {
            "AboutMe" => typeof(AboutMe),
            "ProfessionalExperience" => typeof(ProfessionalExperience),
            "Education" => typeof(Education),
            "Languages" => typeof(Languages),
            "Programming" => typeof(Programming),
            "Skills" => typeof(Skills),
            "SideProjects" => typeof(SideProjects),
            _ => throw new InvalidOperationException($"{navigationViewItem.Name} is not a valid page.")
        };

        if(ContentFrame.Content?.GetType() != pageType)
        {
            ContentFrame.Navigate(pageType);
        } 
    }

    public void OnNavigationViewPaneClosed(NavigationView sender, object args) => Footer.Visibility = Visibility.Collapsed;

    public void OnNavigationViewPaneOpened(NavigationView sender, object args) => Footer.Visibility = Visibility.Visible;

    public void OnLanguageSelectionChanged(object sender, SelectionChangedEventArgs args)
    {
        if (args.AddedItems[0] is not string selectedLanguage)
        {
            return;
        }

        _localizationService.ChangeLanguage(selectedLanguage);
    }

    private void OnLanguageChanged(object? sender, PropertyChangedEventArgs e) => PopulateText();

    private void PopulateText()
    {
        AboutMe.Content = _localizationService["AboutMe/NavigationViewItemContent"];
        ProfessionalExperience.Content = _localizationService["ProfessionalExperience/NavigationViewItemContent"];
        Education.Content = _localizationService["Education/NavigationViewItemContent"];
        Languages.Content = _localizationService["Languages/NavigationViewItemContent"];
        Programming.Content = _localizationService["Programming/NavigationViewItemContent"];
        Skills.Content = _localizationService["Skills/NavigationViewItemContent"];
        SideProjects.Content = _localizationService["SideProjects/NavigationViewItemContent"];
    }
}
