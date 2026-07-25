using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MonkeyFinder.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonkeyFinder.ViewModels
{
    [QueryProperty("Monkey", "Monkey")]
    public partial class DetailsViewModel:BaseViewModel
    {
        IMap map;
        public DetailsViewModel(IMap _map)
        {
            map = _map;
        }

        [ObservableProperty]
        Monkey monkey;

        [RelayCommand]
        async Task OpenMapAsync()
        {
            try
            {
                await map.OpenAsync(Monkey.Latitude, Monkey.Longitude, new MapLaunchOptions
                {
                    Name=Monkey.Name,
                    NavigationMode=NavigationMode.Driving
                }

                    );
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlertAsync("Error", $"Unable to open map {ex.Message}", "Ok");
            }
        }
    }
}
