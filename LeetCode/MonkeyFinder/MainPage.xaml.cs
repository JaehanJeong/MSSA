using MonkeyFinder.ViewModels;

namespace MonkeyFinder
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage(MonkeysViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }


    }
}
