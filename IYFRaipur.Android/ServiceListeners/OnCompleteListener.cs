using System;
using System.Threading.Tasks;
using Android.Gms.Tasks;
using Firebase.Auth;
using Firebase.Firestore;
using IYFRaipur.Models;

namespace IYFRaipur.Droid.ServiceListeners
{
    public class OnCompleteListener : Java.Lang.Object, IOnCompleteListener
    {
        private TaskCompletionSource<DataClass> _tcs;

        public OnCompleteListener(TaskCompletionSource<DataClass> tcs)
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
                    var user = new DataClass();
                    user.UserName = doc.Id;
                    user.Email = doc.GetString("email");
                    user.Name = doc.GetString("firstname");
                    //user.Image = doc.GetString("image");
                    _tcs.TrySetResult(user);
                    return;
                }
            }
            // something went wrong
            _tcs.TrySetResult(default(DataClass));
        }
    }
}
