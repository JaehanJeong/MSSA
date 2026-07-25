using CommunityToolkit.Mvvm.Input;
using MonkeyFinder.Models;
using MonkeyFinder.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MonkeyFinder.ViewModels
{
    public partial class MonkeysViewModel:BaseViewModel
    {
        MonkeyService monkeyService;
        IConnectivity connectivity;
        IGeolocation geolocation;
        //dependency injection
        public MonkeysViewModel(MonkeyService _monkeyService, IConnectivity _connectivity, IGeolocation _geolocation)
        {
            monkeyService = _monkeyService;
            connectivity = _connectivity;
            geolocation = _geolocation;
        }
        
        public ObservableCollection<Monkey> Monkeys { get; } = new();
        [RelayCommand]
        async Task GetMonkeysAsync ()
        {
            if(IsBusy) return;
            try
            {
                if(connectivity.NetworkAccess!=NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlertAsync("No connectivity", "Please check internet", "OK");
                    return;
                }
                IsBusy = true;
                var monkeys = await monkeyService.GetMonkeysAsync();
                if(Monkeys.Count != 0)
                {
                    Monkeys.Clear();
                }
                foreach(var monkey in monkeys)
                {
                    Monkeys.Add(monkey);
                }
            }
            catch(Exception ex)
            {
                await Shell.Current.DisplayAlertAsync("Error", $"Unable to retrieve monkeys {ex.Message}", "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        async Task GetClosestMonkey()
        {
            if(IsBusy || Monkeys.Count == 0)
            {
                await Shell.Current.DisplayAlertAsync("No Monkeys!", "Get monkeys list first!", "Ok");
            }
            try
            {
                var location = await geolocation.GetLastKnownLocationAsync();
                if(location==null)
                {
                    location = await geolocation.GetLocationAsync(new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.Medium,
                        Timeout = TimeSpan.FromSeconds(30)
                    });
                }
                if (location == null)
                {
                    await Shell.Current.DisplayAlertAsync("Error", "Unable to get location", "Ok");
                    return;
                }
                var first = Monkeys.OrderBy(m => location.CalculateDistance(m.Latitude, m.Longitude, DistanceUnits.Miles)).FirstOrDefault();
                if(first!=null)
                {
                    await Shell.Current.DisplayAlertAsync("Closest Monkey", $"{first.Name} is the closest, located at {first.Location}", "Ok");
                }
            }

            catch (Exception ex)
            {
                await Shell.Current.DisplayAlertAsync("Error!", $"Unable to get closest monkey {ex.Message}", "Ok");
            }
        }

        [RelayCommand]
        async Task GoToDetailsAsync(Monkey monkey)
        {
            if (monkey == null)
                return;
            await Shell.Current.GoToAsync(nameof(DetailsPage), true, new Dictionary<string, object>
            {
                {"Monkey", monkey }
            }
                
            );
        }

    }
}
