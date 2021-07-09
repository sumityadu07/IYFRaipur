using Android.Gms.Extensions;
using Firebase.Auth;
using Firebase.Firestore;
using IYFRaipur.Droid;
using IYFRaipur.Droid.ServiceListeners;
using IYFRaipur.Models;
using IYFRaipur.Services;
using Java.Util;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(Repository<DataClass>))]

namespace IYFRaipur.Droid
{
    public class Repository<T> : IRepository<T> where T : IIdentifiable
    {
        public Repository()
        {

        }

        public string GetPhone()
            => FirebaseAuth.Instance.CurrentUser.PhoneNumber;

        #region Save Document
        public async Task SaveCouncelor(DataClass data)
        {
            var docRef = FirebaseFirestore.Instance
                        .Collection("councelor")
                        .Document(FirebaseAuth.Instance.CurrentUser.PhoneNumber);

            var userData = new HashMap();
            userData.Put("userName", data.UserName);
            userData.Put("name", data.Name);
            userData.Put("email", data.Email);
            //userData.Put("image", image);

            await docRef.Set(userData);
        }
        public async Task SavePreacher(DataClass data)
        {
            var docRef = FirebaseFirestore.Instance
                        .Collection("preaceher")
                        .Document(FirebaseAuth.Instance.CurrentUser.PhoneNumber);

            var userData = new HashMap();
            userData.Put("userName", data.UserName);
            userData.Put("name", data.Name);
            userData.Put("email", data.Email);
            //userData.Put("image", image);

            await docRef.Set(userData);
        }
        public async Task SaveFacilitator(DataClass data)
        {
            var docRef = FirebaseFirestore.Instance
                        .Collection("facilitator")
                        .Document(FirebaseAuth.Instance.CurrentUser.PhoneNumber);

            var userData = new HashMap();
            userData.Put("userName", data.UserName);
            userData.Put("name", data.Name);
            userData.Put("email", data.Email);
            //userData.Put("image", image);

            await docRef.Set(userData);
        }
        #endregion

        #region GetCurrentDocument
        public Task<T> GetCurrentCouncelor()
        {
            var tcs = new TaskCompletionSource<T>();

            FirebaseFirestore.Instance
                .Collection("councelor")
                .Document(FirebaseAuth.Instance.CurrentUser.PhoneNumber)
                .Get()
                .AddOnCompleteListener(new OnDocumentCompleteListener<T>(tcs));

            return tcs.Task;
        }
        public Task<T> GetCurrentPreacher()
        {
            var tcs = new TaskCompletionSource<T>();

            FirebaseFirestore.Instance
                .Collection("preacher")
                .Document(FirebaseAuth.Instance.CurrentUser.PhoneNumber)
                .Get()
                .AddOnCompleteListener(new OnDocumentCompleteListener<T>(tcs));

            return tcs.Task;
        }
        public Task<T> GetCurrentFacilitator()
        {
            var tcs = new TaskCompletionSource<T>();

            FirebaseFirestore.Instance
                .Collection("facilitator")
                .Document(FirebaseAuth.Instance.CurrentUser.PhoneNumber)
                .Get()
                .AddOnCompleteListener(new OnDocumentCompleteListener<T>(tcs));

            return tcs.Task;
        }
        public Task<T> GetDocumentAsync(string id)
        {
            var tcs = new TaskCompletionSource<T>();

            FirebaseFirestore.Instance
                .Collection("")
                .Document(id)
                .Get()
                .AddOnCompleteListener(new OnDocumentCompleteListener<T>(tcs));

            return tcs.Task;
        }
        #endregion

        #region GetCollection
        public Task<IList<T>> GetCouncelors()
        {
            var tcs = new TaskCompletionSource<IList<T>>();

            FirebaseFirestore.Instance
                             .Collection("councelor")
                             .Get()
                             .AddOnCompleteListener(new OnCollectionCompleteListener<T>(tcs));
            return tcs.Task;
        }
        public Task<IList<T>> GetPreachers()
        {
            var tcs = new TaskCompletionSource<IList<T>>();

            FirebaseFirestore.Instance
                             .Collection("preacher")
                             .Get()
                             .AddOnCompleteListener(new OnCollectionCompleteListener<T>(tcs));
            return tcs.Task;
        }
        public Task<IList<T>> GetFacilitators()
        {
            var tcs = new TaskCompletionSource<IList<T>>();

            FirebaseFirestore.Instance
                             .Collection("")
                             .Get()
                             .AddOnCompleteListener(new OnCollectionCompleteListener<T>(tcs));
            return tcs.Task;
        }
        #endregion

    }
}
