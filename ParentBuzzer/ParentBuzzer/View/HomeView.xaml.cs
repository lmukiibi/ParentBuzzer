using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParentBuzzer.Model;

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
            //userName.Text = user.UserName;
        }
        private void Button_Clicked(object sender, EventArgs e)
        {

        }

    }
}