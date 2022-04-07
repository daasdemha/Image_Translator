
using ImagesTranslator.ViewModels;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ImagesTranslator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private LoginViewModel vm;
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = vm = new LoginViewModel();

        }

        public async void CheckEmailAndPassword()
        {
            if (!vm.CheckLoginDetails())
            {
                await DisplayAlert("Login", "Enter Username And Passowrd", "OK");
            }
        }
       
    }
}