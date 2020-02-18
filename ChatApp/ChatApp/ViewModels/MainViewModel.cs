using ChatApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ChatApp.ViewModels
{
   public class MainViewModel:INotifyPropertyChanged
    {
        public List<Conversation> Messages { get; set; } = Conversations.All;

        public MainViewModel()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
