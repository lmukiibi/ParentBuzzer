using ParentBuzzer.Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParentBuzzer.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : ContentPage
    {
        private User user;

        public HomeView(User user)
        {
            this.user = user;
            InitializeComponent();
        }

        private async void Button_Clicked_Profile(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditProfileView(user));
        }

        private async void Button_Clicked_Search(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchView(user));
        }
    }
}