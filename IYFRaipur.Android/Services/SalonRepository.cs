using Firebase.Auth;
using Firebase.Firestore;
using IYFRaipur.Droid.ServiceListeners;
using IYFRaipur.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace IYFRaipur.Droid.Services
{
    public abstract class SalonRepository<T> : ISalonRepository<T> where T : IIdentifiable
    {
        public Task<T> GetSalonAsync(string id)
        {
            var tcs = new TaskCompletionSource<T>();

            FirebaseFirestore.Instance
                .Collection("salons")
                .Document(id)
                .Get()
                .AddOnCompleteListener(new OnDocumentCompleteListener<T>(tcs));

            return tcs.Task;
        }

        public Task<IList<T>> GetSalonsAsync()
        {
            var tcs = new TaskCompletionSource<IList<T>>();

            FirebaseFirestore.Instance
                             .Collection("salons")
                             .Get()
                             .AddOnCompleteListener(new OnCollectionCompleteListener<T>(tcs));

            return tcs.Task;
        }

    }
}
