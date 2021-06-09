using System;
using System.Threading.Tasks;
using Android.Gms.Tasks;
using Firebase.Auth;
using Firebase.Firestore;
using IYFRaipur.Models;

namespace IYFRaipur.Droid.ServiceListeners
{
    public class OnCheckCompleteListener : Java.Lang.Object, IOnCompleteListener
    {
        private Task<QuerySnapshot> _tcs;

        public OnCheckCompleteListener(Task<QuerySnapshot> tcs)
        {
            _tcs = tcs;
        }

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            if (task.IsSuccessful)
            {
                // process document
                var result = task.Result;
                if (result is DocumentSnapshot doc)
                {
                    var user = new User();
                    user.Id = doc.Id;
                    user.Email = doc.GetString("email");
                    user.Name = doc.GetString("lastname");
                    user.Image = doc.GetString("image");
                    return;
                }
            }
            // something went wrong
        }
    }
}
