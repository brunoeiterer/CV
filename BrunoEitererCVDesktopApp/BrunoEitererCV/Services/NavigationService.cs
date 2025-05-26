using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace BrunoEitererCV.Services;

public class NavigationService
{
    private readonly Lazy<NavigationView> _navigationView;
    private NavigationView NavigationView => _navigationView.Value;

    private readonly Dictionary<Type, NavigationViewItem> NavigationViewItems = [];

    public NavigationService()
    {
        _navigationView = new(() => (Application.Current as App)?.MainWindow.NavigationView ?? 
            throw new InvalidOperationException("Could not get a reference to the current application"));
    }

    public void Navigate(Type target)
    {
        if (!NavigationViewItems.TryGetValue(target, out var item))
        {
            item = NavigationView.MenuItems.OfType<NavigationViewItem>().First(item => item.Name == target.Name);
            NavigationViewItems[target] = item;
        }

        NavigationView.SelectedItem = item;
    }
}
