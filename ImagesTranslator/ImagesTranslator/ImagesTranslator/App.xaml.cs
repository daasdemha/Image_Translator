using ImagesTranslator.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


[assembly: ExportFont("BebasNeue-Regular.ttf", Alias = "BE-R")]
[assembly: ExportFont("Montserrat-Regular.ttf", Alias = "MO-R")]
[assembly: ExportFont("Montserrat-SemiBold.ttf", Alias = "MO-S")]
namespace ImagesTranslator
{
    public partial class App : Application
    {
        public App(AppSetup setup)
        {
            InitializeComponent();
            AppContainer.Container = setup.CreateContainer();
            MainPage = new NavigationPage(new LoginPage());
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
