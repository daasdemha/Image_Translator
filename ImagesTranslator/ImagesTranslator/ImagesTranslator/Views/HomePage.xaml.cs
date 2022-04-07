using Autofac;
using ImagesTranslator.ViewModels;
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
    public partial class HomePage : ContentPage
    {
        private HomeViewModel vm;
        public HomePage()
        {
            InitializeComponent();
            vm = AppContainer.Container.Resolve<HomeViewModel>();
            BindingContext = vm;
        }
    }
}