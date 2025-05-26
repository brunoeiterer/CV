using System.ComponentModel;
using BrunoEitererCV.Services;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace BrunoEitererCV.Pages;

public sealed partial class SideProjects : PageBase
{
    public SideProjects()
    {
        this.InitializeComponent();

        LocalizationService.PropertyChanged += OnLanguageChanged;

        PopulateText();
    }

    public void OnGameExpanderCollapsed(Expander sender, ExpanderCollapsedEventArgs e) => VideoPlayer.MediaPlayer.Pause();

    protected override void OnNavigatingFrom(NavigatingCancelEventArgs e) => VideoPlayer.MediaPlayer.Pause();

    private void OnLanguageChanged(object? sender, PropertyChangedEventArgs e) => PopulateText();

    private void PopulateText()
    {
        RefreshInlines(LifejournalerTextBlock, "Lifejournaler/Text");
        RefreshInlines(PrintReadyTextBlock, "PrintReady/Text");
        RefreshInlines(CVTextBlock, "CV/Text");
        RefreshInlines(GameTextblock, "Game/Text");
        RefreshInlines(BitbucketCommitPlotterTextBlock, "BitbucketCommitPlotter/Text");
        RefreshInlines(IPCAProcessorTextBlock, "IPCAProcessor/Text");
    }
}
