

using CoventryNews.ViewModels;
using ImagesTranslator.Views;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using Rg.Plugins.Popup.Extensions;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace ImagesTranslator.ViewModels
{

    public class LoginViewModel : INotifyPropertyChanged
    {
        #region Properties
        public event PropertyChangedEventHandler PropertyChanged;
        public LoginViewModel()
        {
            TestResult = false;
        }

        public string Email { get; set; }


        public string Password { get; set; }


        public bool TestResult { get; set; }

        #endregion


        #region Method
        public Command LoginCommand
        {
            get
            {
                return new Command(Login);
            }
        }
        public Command AuthCommand
        {
            get
            {
                return new Command(Auth);
            }
        }
        public Command SignUp
        {
            get
            {
                return new Command(() =>
                {
                    TestResult = true;
                    Application.Current.MainPage.Navigation.PushModalAsync(new RegisterPage());
                        // Application.Current.MainPage = new NavigationPage(new RegisterPage());


                    });
            }
        }

        public bool CheckLoginDetails()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                return false;
            }

            return true;
        }

        private async void Login()
        {
            //null or empty field validation, check weather email and password is null or empty

            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                await Application.Current.MainPage.DisplayAlert("", "Please enter Email and Password", "OK");


            else
            {
                //call GetUser function which we define in Firebase helper class
                var user = await FirebaseHelper.GetUser(Email);
                //firebase return null valuse if user data not found in database
                if (user != null)
                    if (Email == user.Email && Password == user.Password)
                    {

                        await Application.Current.MainPage.Navigation.PushPopupAsync(new AlertPage("S", "Login Success"));

                        Application.Current.MainPage = new NavigationPage(new MainPage());
                    }
                    else


                        await Application.Current.MainPage.DisplayAlert("", "Please enter correct Email and Password", "OK");
                else


                    await Application.Current.MainPage.DisplayAlert("", "Login Failed, User not found", "OK");


                TestResult = true;

            }
        }
        private async void Auth()
        {
            bool isFingerprintAvailable = await CrossFingerprint.Current.IsAvailableAsync(false);
            if (!isFingerprintAvailable)
            {
                await Application.Current.MainPage.DisplayAlert("Error",
                    "Biometric authentication is not available or is not configured.", "OK");
                return;
            }

            AuthenticationRequestConfiguration conf =
                new AuthenticationRequestConfiguration("Authentication",
                "Authenticate access to your personal data");

            var authResult = await CrossFingerprint.Current.AuthenticateAsync(conf);
            if (authResult.Authenticated)
            {
                //Success  
                App.Current.MainPage = new NavigationPage(new MainPage());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Authentication failed", "OK");

            }
            TestResult = true;
        }

        #region unit test
        public async Task<Model.Users> ChekUserCredetials()
        {
            var user = await FirebaseHelper.GetUser(Email);

            return user;
        }

        public async Task<bool> CheckDeviceSupportFingerPrint()
        {
            bool isFingerprintAvailable = await CrossFingerprint.Current.IsAvailableAsync(false);

            return isFingerprintAvailable;
        }

        #endregion
    }
    #endregion
}
