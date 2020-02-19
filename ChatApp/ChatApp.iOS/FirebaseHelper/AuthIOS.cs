using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatApp.Interfaces;
using ChatApp.iOS.FirebaseHelper;
using Firebase.Auth;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(AuthIOS))]
namespace ChatApp.iOS.FirebaseHelper
{
    public class AuthIOS : IAuth
    {
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            try
            {
                var user = await Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
                return await user.User.GetIdTokenAsync();
            }
            catch (Exception e)
            {
                return "";
            }

        }
    }
}