using ChatApp.Interfaces;
using ChatApp.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using XF.Material.Forms.UI.Dialogs;

namespace ChatApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private IAuth auth;
        private string Token;
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
            using (await MaterialDialog.Instance.LoadingDialogAsync(message: "Cargando..."))
            {
                 Token = await auth.LoginWithEmailPassword(UserName+"@gmail.com", Password);
                 Preferences.Set("token", Token);
            }

       
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
            await MaterialDialog.Instance.SnackbarAsync(message: "Usuario o Contraseña estan incorrecto. Trate de nuevo!",
                                                         actionButtonText: "Ok",
                                                        msDuration: MaterialSnackbar.DurationLong);
           // await App.Current.MainPage.DisplayAlert("Error", "Usuario o Contraseña estan incorrecto. Trate de nuevo!", "OK");
        }
    }
}
 