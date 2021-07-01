using ParentBuzzer.Service;
using ParentBuzzer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParentBuzzer.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            //await UserDB.AddUser(UserName.Text, Email.Text, Password.Text, City.Text);
            var user = await UserDB.GetUser(Email.Text, Password.Text);

            if (user != null)
            {
                await Navigation.PushAsync(new HomeView(user));
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Inloggning misslyckades", "Användaren existerar inte", "Försök igen");
            }
        }
    }
}