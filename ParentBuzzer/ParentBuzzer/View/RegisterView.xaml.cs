using ParentBuzzer.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

            bool emailExists = await IfEmailExists(Email.Text);

            if (string.IsNullOrEmpty(UserName.Text))
            {
                errorMessage.Add("Du saknar användarnamn, vänligen fyll i detta.");
            }

            if (string.IsNullOrEmpty(Email.Text) || !Email.Text.Contains("@"))
            {
                errorMessage.Add("Du saknar email, vänligen fyll i detta.");
            }

            if (string.IsNullOrEmpty(Password.Text) || Password.Text.Length < 6)
            {
                errorMessage.Add("Lösenord saknas eller är kortare än 6 tecken, vänligen fyll i detta.");
            }

            if (string.IsNullOrEmpty(City.Text))
            {
                errorMessage.Add("Du saknar stad, vänligen fyll i detta.");
            }

            if (errorMessage.Count > 0)
            {
                var messages = String.Join(" \n", errorMessage);
                await App.Current.MainPage.DisplayAlert("Felmeddelande", messages, "Ok");
            }
            else
            {
                if (emailExists)
                {
                    await App.Current.MainPage.DisplayAlert("Registrering misslyckad!", "Användaren existerar redan", "Försök igen");
                }
                else
                {
                    await UserDB.AddUser(UserName.Text, Email.Text, Password.Text, City.Text, 0, false, false, DateTime.Now, "");
                    await App.Current.MainPage.DisplayAlert("Registrering lyckad!", "Du har nu registrerat ett konto hos oss.", "Start buzzing!");
                    var user = await UserDB.GetUser(Email.Text, Password.Text);
                    await Navigation.PushAsync(new HomeView(user));
                }
            }
        }

        /// <summary>
        /// Checks if an email exists in the UserDB. Returns false if you are enable to register.
        /// </summary>
        /// <param name="email"></param>
        /// <returns>bool</returns>
        public static async Task<bool> IfEmailExists(string email)
        {
            bool exists = await UserDB.IfEmailExists(email);
            if (exists)
            {
                return true;
            }
            return false;
        }
    }
}