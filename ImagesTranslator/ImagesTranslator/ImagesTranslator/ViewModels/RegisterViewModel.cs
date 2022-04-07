using CoventryNews.ViewModels;

using ImagesTranslator.Views;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ImagesTranslator.ViewModels
{
  public class RegisterViewModel : INotifyPropertyChanged
    {
        #region Properties
        public Command NavigateLoginPage
        {
            get
            {
                return new Command(() =>
                {
                    Application.Current.MainPage.Navigation.PopAsync();

                });
            }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Name"));
            }
        }
        private string stnumber;
        public string Student_number
        {
            get { return stnumber; }
            set
            {
                stnumber = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Student_number"));
            }
        }

        private string phno;
        public string Phone_number
        {
            get { return phno; }
            set
            {
                phno = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Phone_number"));
            }
        }
        private string dp;
        public string Department
        {
            get { return dp; }
            set
            {
                dp = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Department"));
            }
        }
       
       
       
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        private string confirmpassword;
        public string ConfirmPassword
        {
            get { return confirmpassword; }
            set
            {
                confirmpassword = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ConfirmPassword"));
            }
        }

        #endregion

        #region Method
        public Command SignUpCommand
        {
            get
            {
                return new Command(async() =>
                {
                    if (Password == ConfirmPassword)
                        SignUp();
                    else
                        await Application.Current.MainPage.Navigation.PushPopupAsync(new AlertPage("E", "Password must be same as above!"));
                });
            }
        }
        private async void SignUp()
        {
            //null or empty field validation, check weather email and password is null or empty

            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                
            await Application.Current.MainPage.Navigation.PushPopupAsync(new AlertPage("E", " Empty Values,Please enter Email and Password"));
            else
            {
                //call AddUser function which we define in Firebase helper class
                var user = await FirebaseHelper.AddUser(Name, Student_number, Phone_number, Department, Email, Password);
                //AddUser return true if data insert successfuly 
                if (user)
                {
                    
                    await Application.Current.MainPage.Navigation.PushPopupAsync(new AlertPage("S", " Successfully SignUp "));
                    //Navigate to Wellcom page after successfuly SignUp
                    //pass user email to welcom page
                   await Application.Current.MainPage.Navigation.PopAsync();
                }
                else
                   
                await Application.Current.MainPage.Navigation.PushPopupAsync(new AlertPage("E", " SignUp Failed"));

            }
        }

        #region Unit Test
        public async Task<bool> UserSiginUp(string Name, string Student_number, string Phone_number, string Department, string Email, string Password)
        {
            var user = await FirebaseHelper.AddUser(Name, Student_number, Phone_number, Department, Email, Password);

            return user;
        }

        #endregion
        #endregion
    }
}
