using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.ViewModels
{
    [QueryProperty("Text", "TaskName")]
    public partial class DetailsViewModel:ObservableObject
    {

        [ObservableProperty]
        string taskName;


        [RelayCommand]
        async Task Back()
        {

            await Shell.Current.GoToAsync("..");
        }

    }
}
