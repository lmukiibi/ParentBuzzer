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
    public partial class EditProfileView : ContentPage
    {
        private User user;
        public EditProfileView(User user)
        {
            this.user = user;
            InitializeComponent();
            UserName.Text = user.UserName;
            Email.Text = user.Email;
            Password.Text = user.Password;
            City.Text = user.City;          
            ExpectedChild.IsChecked = user.ExpectingChild;
            HasChild.IsChecked = user.HasChild;
            Hobbies.Text = user.Hobbies;

            if (user.ChildsBirth.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
            {
                ChildsBirth.Text = "";
            }
            else
            {
                ChildsBirth.Text = user.ChildsBirth.ToString("yyyy-MM-dd");
            }

            if (user.Age == 0)
            {
                Age.Text = "";
            }
            else
            {
                Age.Text = user.Age.ToString();
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            int AgeOfUser = ConvertAgeToInt(Age.Text);
            DateTime childsBirth = ConvertChildsBirthToDateTime(ChildsBirth.Text);
            var updatedUser = await UserDB.UpdateUser(user, UserName.Text, Email.Text, Password.Text, City.Text, AgeOfUser, ExpectedChild.IsChecked, HasChild.IsChecked, childsBirth, Hobbies.Text);           
            await App.Current.MainPage.DisplayAlert("Min profil", "Ändringar har sparats", "Ok");
            await Navigation.PopAsync();
        }

        public int ConvertAgeToInt(string age)
        {
            if(string.IsNullOrEmpty(age.Trim()))
            {
                return 0;
            }
            try
            { 
               return Convert.ToInt32(age);                
            }
            catch
            {
                return 0;
            }
        }
        public DateTime ConvertChildsBirthToDateTime(string childsBirth)
        {
            if (string.IsNullOrEmpty(childsBirth.Trim()))
            {
                return DateTime.Now;
            }
            try
            {
                return Convert.ToDateTime(childsBirth);
            }
            catch
            {
                return DateTime.Now;
            }
        }
    }
}