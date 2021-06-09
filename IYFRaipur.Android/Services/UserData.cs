using Firebase.Auth;
using Java.Util;
using IYFRaipur.Droid;
using IYFRaipur.Models;
using IYFRaipur.Services;
using System.Threading.Tasks;
using Firebase.Firestore;
using Android.Gms.Extensions;
using IYFRaipur.Droid.ServiceListeners;
using Xamarin.Essentials;

[assembly: Xamarin.Forms.Dependency(typeof(UserData))]
namespace IYFRaipur.Droid
{
    public class UserData : IUserData
    {
        public string GetPhone()
            => FirebaseAuth.Instance.CurrentUser.PhoneNumber;

        public async void Save(string name, string email,string image)
        {
            var docRef = FirebaseFirestore.Instance
                        .Collection("users")
                        .Document(FirebaseAuth.Instance.CurrentUser.Uid);

            var userData = new HashMap();
            userData.Put("name", name);
            userData.Put("email", email);
            userData.Put("image", image);

            await docRef.Set(userData);
        }
        public async void Save(string accountType)
        {
            var docRef = FirebaseFirestore.Instance
                        .Collection("users")
                        .Document(FirebaseAuth.Instance.CurrentUser.Uid);

            var userData = new HashMap();
            userData.Put("accountType", accountType);

            await docRef.Set(userData);
        }

        public Task<User> GetUserAsync()
        {
            var tcs = new TaskCompletionSource<User>();

            FirebaseFirestore.Instance
                .Collection("users")
                .Document(FirebaseAuth.Instance.CurrentUser.Uid)
                .Get()
                .AddOnCompleteListener(new OnCompleteListener(tcs));

            return tcs.Task;
        }
        //public void IsExistingUser()
        //{
        //    var currentUid = FirebaseAuth.Instance.CurrentUser.Uid;
        //    var firebaseFirestore = FirebaseFirestore.GetInstance();
        //    CollectionReference collectionReference = firebaseFirestore.Collection("users");
        //    Query userQuery = collectionReference.WhereEqualTo("Id", currentUid);
        //    userQuery.Get().AddOnCompleteListener(new OnCheckCompleteListener);

        //}

    }
}