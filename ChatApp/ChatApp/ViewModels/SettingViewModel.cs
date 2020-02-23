using ChatApp.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using XF.Material.Forms.UI.Dialogs;

namespace ChatApp.ViewModels
{
    public class SettingViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand LogoutCommand => new RelayCommand(goToLoginPage);

        public SettingViewModel()
        {

        }

        private async void goToLoginPage()
        {
            using (await MaterialDialog.Instance.LoadingDialogAsync(message: "Saliendo..."))
            {
                Preferences.Set("token", "");
                App.Current.MainPage = new LoginPage();
            }
        }
    }
}
