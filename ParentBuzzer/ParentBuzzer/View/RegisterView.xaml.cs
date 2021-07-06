using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ParentBuzzer.Service;
using ParentBuzzer.View;
using ParentBuzzer.Model;

namespace ParentBuzzer.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterView : ContentPage
    {
        public RegisterView()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            List<string> errorMessage = new List<string>();


            if (UserName.Text == null)
            {
                errorMessage.Add("Felmeddelande. Du saknar användarnamn, vänligen fyll i detta.");
                //await App.Current.MainPage.DisplayAlert("Felmeddelande","Du saknar användarnamn", "vänligen fyll i detta.");
            }

            if (Email.Text == null || !Email.Text.Contains("@"))
            {
                errorMessage.Add("Felmeddelande. Du saknar email, vänligen fyll i detta.");

                //await App.Current.MainPage.DisplayAlert("Felmeddelande", "Du saknar email", "vänligen fyll i detta.");

            }

            if (Password.Text == null || Password.Text.Length < 5)
            {
                errorMessage.Add("Felmeddelande. Lösenord saknas eller är kortare än 6 tecken, vänligen fyll i detta.");

                //await App.Current.MainPage.DisplayAlert("Lösenord saknas eller", "är kortare än 6 tecken", "vänligen fyll i detta.");

            }

            if (City.Text == null)
            {
                errorMessage.Add("Felmeddelande. Du saknar stad, vänligen fyll i detta.");

                //await App.Current.MainPage.DisplayAlert("Felmeddelande", "Du saknar stad", "vänligen fyll i detta.");
            }

            if (errorMessage.Count > 0)
            {
                //skriv ut lista med error
            }
            else
            {
                await UserDB.AddUser(UserName.Text, Email.Text, Password.Text, City.Text);
                await App.Current.MainPage.DisplayAlert("Registrering lyckad!", "Du har nu registrerat ett konto hos oss.", "Start buzzing!");
                var user = await UserDB.GetUser(Email.Text, Password.Text);
                await Navigation.PushAsync(new HomeView(user));

            }


        }
    }
}