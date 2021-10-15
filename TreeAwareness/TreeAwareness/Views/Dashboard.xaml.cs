using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TreeAwareness.Services;
using TreeAwareness.Views;



namespace TreeAwareness.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        iAuth auth;
        public Dashboard()
        {

            InitializeComponent();
            BindingContext = new Dashboard();
            auth = DependencyService.Get<iAuth>();
        }




        void SignOutButton_Clicked(object sender, EventArgs e)
        {
            var signOut = auth.SignOut();
            if (signOut)
            {
                Application.Current.MainPage = new MainPage();
            }
        }

    }

    }

