using ChatApp.Interfaces;
using ChatApp.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChatApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private IAuth auth;
        public event PropertyChangedEventHandler PropertyChanged;
        public string UserName { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand => new RelayCommand(validaterLogin);
        public ICommand RegisterCommand => new RelayCommand(goToRegister);

        public LoginViewModel()
        {
            auth = DependencyService.Get<IAuth>();
        }
        public async void validaterLogin()
        {
            
            string Token = await auth.LoginWithEmailPassword(UserName, Password);
            if (Token != "")
            {
                await App.Current.MainPage.Navigation.PushModalAsync(new MainPage());
            }
            else
            {
                ShowError();
            }
        }

        public async void goToRegister()
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new RegisterPage()));
        }
        async private void ShowError()
        {
            await App.Current.MainPage.DisplayAlert("Error", "Usuario o Contraseña estan incorrecto. Trate de nuevo!", "OK");
        }
    }
}
