using ImagesTranslator.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ImagesTranslator
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

           MainPage = new NavigationPage(new ImagesTranslator.Views.CarouselView());
           // MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
