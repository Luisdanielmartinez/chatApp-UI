using ChatApp.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatApp
{
    public partial class App : Application
    {
        private string token;
        public App()
        {
            InitializeComponent();
            XF.Material.Forms.Material.Init(this);
            token = getToken();
            if (token=="")
            {
                MainPage = new LoginPage();
                return;
            }
            MainPage = new MainPage();
        }

        private string getToken()
        {
           return Preferences.Get("token", "");
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }
        
        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
