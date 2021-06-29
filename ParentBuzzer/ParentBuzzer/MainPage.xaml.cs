using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ParentBuzzer.View;

namespace ParentBuzzer
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Register_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterView());

        }

        private void Login_Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}
