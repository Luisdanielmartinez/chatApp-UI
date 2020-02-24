using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatApp.iOS.Service;
using ChatApp.Models;
using ChatApp.RepositoryInterface;
using ChatApp.Settings;
using Foundation;
using Newtonsoft.Json;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(ChatApp.iOS.PlasformImplementations.UserRepositoryIos))]
namespace ChatApp.iOS.PlasformImplementations
{
    public class UserRepositoryIos : IRepository<User>
    {
        Firebase.CloudFirestore.Firestore db = FirebaseService.Instance;
        public async Task<User> GetOneAsync(string id)
        {
            var response = db.GetCollection(CommonSettings.collectionUser).GetDocument(id).GetDocumentAsync();
            var user = JsonConvert.DeserializeObject<User>(response.ToString());
            return user;
        }

        public async Task<bool> Save(User obj)
        {

            try
            {
                var keys = new[]
                {
                    new NSString( "UserName"),
                    new NSString("Tell"),
                    new NSString("Name"),
                    new NSString("key4"),
                    new NSString( "Id"),
                    new NSString( "LastName"),
                    new NSString("Country"),
                    new NSString( "State"),
                    new NSString("Password"),
                    new NSString("PhotoPerfile"),
                      new NSString("Token"),
                };

                var objects = new NSObject[]
                {
                    // don't have to be strings... can be any NSObject.
                    new NSString(obj.UserName),
                    new NSString(obj.Tell),
                    new NSString(obj.Name),
                    new NSNumber(obj.Id),
                    new NSString(obj.LastName),
                    new NSString(obj.Country),
                    new NSString( obj.State),
                    new NSString(obj.Password),
                    new NSString(obj.PhotoPerfile),
                    new NSString(obj.Token),
                 };

                var data = new NSDictionary<NSString, NSObject>(keys,objects);
              
               await db.GetCollection(CommonSettings.collectionUser).GetDocument(obj.Token).SetDataAsync(data);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}