using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TaskManager.ViewModels
{
    // ObservableObject gives implementation for property changes to reflect on the views
    public partial class MainViewModel: ObservableObject
    {
        IConnectivity connectivity;
        public MainViewModel(IConnectivity _connectivity)
        {
            connectivity = _connectivity;
            Tasks = new ObservableCollection<string>();
            
        }

        //this observable property createse a public property which can be bound and it is observed
        // observed: if change is made on either front or back end, it's observed 
        [ObservableProperty]
        string taskName;

        [ObservableProperty]
        ObservableCollection<String> tasks; // collection of tasks

        // this exposes the private method in the view
        [RelayCommand]
        async void Add()
        {
            //Validation
            if(string.IsNullOrEmpty(TaskName))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Task name cannot be empty", "Ok");
                return;
            }
            //Checking for internet connectivity
            if(connectivity.NetworkAccess!=NetworkAccess.Internet)
            {
                await App.Current.MainPage.DisplayAlert("Error", "No internet connection, try later", "Ok");
                return;
            }
            Tasks.Add(taskName);
            TaskName = string.Empty; // automatically clear the textbox control in the view
        }

        [RelayCommand]
        void Delete(string item)
        {
            if(Tasks.Contains(item))
            {
                Tasks.Remove(item); // updated task list will be displayed on the view
            }
        }

        async Task Tap(string s)
        {
            await Shell.Current.GoToAsync($"{nameof(DetailsPage)}?Text={s}");
        }
    }
}
