using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase;
using Firebase.Firestore;

namespace ChatApp.Droid.Services
{
   public static class FirebaseService
    {
        private static FirebaseApp app;
        public static FirebaseFirestore Instance
        {
            get
            {
                return FirebaseFirestore.GetInstance(app);
            }
        }
        public static string AppName { get; } = "ChatApp";

        public static void Init(Android.Content.Context context)
        {
            var baseOptions = FirebaseOptions.FromResource(context);
            // This HACK will be not needed, fixed in https://github.com/xamarin/GooglePlayServicesComponents/commit/723ebdc00867a4c70c51ad2d0dcbd36474ce8ff1
            var options = new FirebaseOptions.Builder(baseOptions).SetProjectId(baseOptions.StorageBucket.Split('.')[0]).Build();
            app = FirebaseApp.InitializeApp(context, options, AppName);
        }
    }
}