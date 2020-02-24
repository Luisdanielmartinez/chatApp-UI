using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ChatApp.Droid.Services;
using ChatApp.Models;
using ChatApp.RepositoryInterface;
using ChatApp.Settings;
using Firebase.Firestore;
using Java.Util;
using Newtonsoft.Json;
using Xamarin.Forms;

[assembly: Dependency(typeof(ChatApp.Droid.PlaformImplementations.UserRepository))]
namespace ChatApp.Droid.PlaformImplementations
{
    public class UserRepository : IRepository<User>
    {
        FirebaseFirestore db = FirebaseService.Instance;
        public async Task<User> GetOneAsync(string id)
        {
             var response = db.Collection(CommonSettings.collectionUser).Document(id).Get().Result;
             var user= JsonConvert.DeserializeObject<User>(response.ToString());
             return user;
        }

        public async Task<bool> Save(User obj)
        {
            
            try
            {
                HashMap data = new HashMap();
                data.Put("UserName",obj.UserName);
                data.Put("Tell", obj.Tell);
                data.Put("Name", obj.Name);
                data.Put("Id",obj.Id);
                data.Put("LastName",obj.LastName);
                data.Put("Country",obj.Country);
                data.Put("State",obj.State);
                data.Put("Password",obj.Password);
                data.Put("PhotoPerfile",obj.PhotoPerfile);
                data.Put("Token",obj.Token);
                 db.Collection(CommonSettings.collectionUser).Document(obj.Token).Set(data);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
   
        }
    }
}