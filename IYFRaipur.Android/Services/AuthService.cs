using Firebase;
using Firebase.Auth;
using System.Linq;
using Java.Util.Concurrent;
using IYFRaipur.Droid;
using IYFRaipur.Services;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Firebase.Firestore;
using IYFRaipur.Models;

[assembly: Xamarin.Forms.Dependency(typeof(AuthService))]
namespace IYFRaipur.Droid
{
    public class AuthService : PhoneAuthProvider.OnVerificationStateChangedCallbacks,IAuthService
    {
        const int OTP_TIMEOUT = 30; // seconds
        private TaskCompletionSource<bool> _phoneAuthTcs;
        private string _verificationId;

        public bool IsSignIn()
            => FirebaseAuth.Instance.CurrentUser != null;

        public void SignOut()
            => FirebaseAuth.Instance.SignOut();

        [System.Obsolete]
        public Task<bool> SendOtpCodeAsync(string phoneNumber)
        {
            _phoneAuthTcs = new TaskCompletionSource<bool>();
            PhoneAuthProvider.Instance.VerifyPhoneNumber(
                "+91" + phoneNumber,
                OTP_TIMEOUT,
                TimeUnit.Seconds,
                Platform.CurrentActivity,
                this);
            return _phoneAuthTcs.Task;
        }

        public override void OnCodeSent(string verificationId, PhoneAuthProvider.ForceResendingToken forceResendingToken)
        {
            base.OnCodeSent(verificationId, forceResendingToken);
            _verificationId = verificationId;
            _phoneAuthTcs?.TrySetResult(true);
        }
        public Task<bool> VerifyOtpCodeAsync(string code)
        {
            if (!string.IsNullOrWhiteSpace(_verificationId))
            {
                var credential = PhoneAuthProvider.GetCredential(_verificationId, code);
                var tcs = new TaskCompletionSource<bool>();
                FirebaseAuth.Instance.SignInWithCredentialAsync(credential)
                    .ContinueWith((task) => OnAuthCompleted(task, tcs));
                return tcs.Task;
            }
            return Task.FromResult(false);
        }

        private void OnAuthCompleted(Task task, TaskCompletionSource<bool> tcs)
        {
            if (task.IsCanceled || task.IsFaulted)
            {
                // something went wrong0
                tcs.SetResult(false);
                return;
            }
            _verificationId = null;
            tcs.SetResult(true);
        }
        public override void OnVerificationFailed(FirebaseException exception)
        {
            System.Diagnostics.Debug.WriteLine("Verification Failed: " + exception.Message);
            _phoneAuthTcs?.TrySetResult(false);
        }

        public override void OnVerificationCompleted(PhoneAuthCredential credential)
        {
            System.Diagnostics.Debug.WriteLine("PhoneAuthCredential created Automatically");
        }
        
    }
}