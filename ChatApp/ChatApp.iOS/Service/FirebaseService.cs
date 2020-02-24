using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace ChatApp.iOS.Service
{
    public static class FirebaseService
    {
        public static Firebase.CloudFirestore.Firestore Instance
        {
            get
            {
                return Firebase.CloudFirestore.Firestore.SharedInstance;
            }
        }

        public static void Init()
        {
            Firebase.Core.App.Configure();
        }
    }
}