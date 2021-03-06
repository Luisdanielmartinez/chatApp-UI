﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ChatApp.Droid.Firebase;
using ChatApp.Interfaces;
using Firebase.Auth;
using Xamarin.Forms;

[assembly: Dependency(typeof(AuthDroid))]
namespace ChatApp.Droid.Firebase
{
    public class AuthDroid: IAuth
    {
        public async Task<string> CreateUserWithEmailPassword(string email, string password)
        {
            var error = "";
            try
            {
                FirebaseAuth.Instance.CreateUserWithEmailAndPassword(email,password);
            }
            catch (FirebaseAuthInvalidUserException e)
            {
                error = "El usuario ya existe, escriba otro usuario";
            }
            return error;
        }

        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            try
            {
                var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email.Trim(), password);
                var token = await user.User.GetIdTokenAsync(false);
                return token.Token;
            }
            catch (Exception ex)
            {
               // ex.PrintStackTrace();
                return "";
            }
            //catch (FirebaseAuthInvalidUserException e)
            //{
            //    e.PrintStackTrace();
            //    return "";
            //}
        }

        public async Task<string> LogOutUser()
        {
            try
            {
                FirebaseAuth.Instance.SignOut();
                return "logout";
            }
            catch (Exception e)
            {
                return "";
            }
        }
    }
}