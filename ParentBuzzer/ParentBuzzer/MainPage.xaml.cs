using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ParentBuzzer.View;
using ParentBuzzer.Service;

namespace ParentBuzzer
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Register_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterView());
        }

        private async void Login_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginView());
            
            /*var list = await UserDB.GetUsers();
            string a = "";
            foreach (var v in list)
            {
                a = v.UserName;
                break;
            }
            await App.Current.MainPage.DisplayAlert("User", a, "OK");*/
        }
    }
}
