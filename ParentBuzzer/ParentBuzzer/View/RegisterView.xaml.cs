﻿using System;
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
            var user = await UserDB.AddUser(UserName.Text, Email.Text, Password.Text, City.Text);
            await App.Current.MainPage.DisplayAlert("Registrering lyckad!", "Du har nu registrerat ett konto hos oss.", "Start buzzing!");
            await Navigation.PushAsync(new HomeView(user));
        }
    }
}