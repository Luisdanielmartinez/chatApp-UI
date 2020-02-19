using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ChatApp.ViewModels
{
    public class RegisterViewModel
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public ICommand SaveCommand => new RelayCommand(saveData);
        public ICommand CancelCommand => new RelayCommand(Cancel);
        public RegisterViewModel()
        {

        }
        private async void saveData()
        {
        
        }
        private async void Cancel()
        {
            await App.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
