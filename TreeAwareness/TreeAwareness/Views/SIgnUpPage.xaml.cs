using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TreeAwareness.Services;

namespace TreeAwareness.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SIgnUpPage : ContentPage
    {
        iAuth auth;
        public SIgnUpPage()
        {
            InitializeComponent();
            auth = DependencyService.Get<iAuth>();
        }


        async void SignUpClicked(object sender, EventArgs e)
        {
            var user = auth.SignUpWithEmailAndPassword(EmailInput.Text, PasswordInput.Text);
            if (user != null)
            {
                await DisplayAlert("Success", "New User Created", "ok");
                var signOut = auth.SignOut();
                if (signOut)
                {
                    Application.Current.MainPage = new MainPage();
                }
            }
            else
            {
                await DisplayAlert("Error", "Something went wrong, please try again", "ok");
            }
        }
    }
}