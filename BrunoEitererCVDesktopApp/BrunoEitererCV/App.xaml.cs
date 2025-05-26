using System;
using System.Net;
using BrunoEitererCV.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;

namespace BrunoEitererCV;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : Application
{
    public IServiceProvider ServiceProvider { get; private set; }

    private Window? m_window;

    public MainWindow MainWindow => m_window as MainWindow ?? throw new InvalidOperationException("Main window is null or has an invalid type");

    /// <summary>
    /// Initializes the singleton application object. This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        this.InitializeComponent();
        var serviceProvider = new ServiceCollection()
            .AddSingleton<NavigationService>()
            .AddSingleton<LocalizationService>();
        ServiceProvider = serviceProvider.BuildServiceProvider();
    }

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="args">Details about the launch request and process.</param>
    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        m_window = new MainWindow();
        m_window.Activate();
    }
}
