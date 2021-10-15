using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using TreeAwareness.Services;

namespace TreeAwareness
{
    public partial class MainPage : ContentPage
    {
        iAuth auth;
        public MainPage()
        {
            InitializeComponent();
            auth = DependencyService.Get<iAuth>();
        }
        async void LoginClicked(object sender, EventArgs e)
        {
            string token = await auth.LoginWithEmailAndPassword(EmailInput.Text, PasswordInput.Text);
            if(token != string.Empty)
            {
                Application.Current.MainPage = new NavigationPage(new Views.Dashboard());
            }
            else
            {
                await DisplayAlert("Authentication Failed", "Email or Password are incorrect", "ok");
            }

        }

        void SignUpClicked(object sender, EventArgs e)
        {
            var signOut = auth.SignOut();
            if (signOut)
            {
                Application.Current.MainPage = new Views.SIgnUpPage();
            }
        }

    }
}
