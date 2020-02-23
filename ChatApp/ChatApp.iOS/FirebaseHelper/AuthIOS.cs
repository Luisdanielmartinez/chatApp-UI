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
        public async Task<string> CreateUserWithEmailPassword(string email, string password)
        {
            var error = "";
            try
            {
                await Auth.DefaultInstance.CreateUserAsync(email,password);
                return error;
            }
            catch (Exception e)
            {
                error = "El usuario ya existe, escriba otro usuario";
            }
            return error;
        }

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

        public async Task<string> LogOutUser()
        {
            try
            {
                NSError error;
                Auth.DefaultInstance.SignOut(out error);
                return "logout";
            }
            catch (Exception e)
            {
                return "";
            }
        }
    }
}