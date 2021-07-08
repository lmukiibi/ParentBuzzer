using ParentBuzzer.Model;
using ParentBuzzer.Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParentBuzzer.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchView : ContentPage
    {
        private User user;

        public SearchView(User user)
        {
            this.user = user;
            InitializeComponent();
            DisplayUsers(user);
        }

        private ObservableCollection<User> users = new ObservableCollection<User>();
        public ObservableCollection<User> Users { get { return users; } }

        public async void DisplayUsers(User user)
        {
            City.Text = user.City;
            searchView.ItemsSource = users;

            var userList = await UserDB.GetUsers(user);
            List<User> list = (List<User>)userList.ToList<User>();
            foreach (var i in list)
            {
                if (user.UserName != i.UserName)
                {
                    users.Add(new User { UserName = i.UserName });
                }
            }
        }
    }
}