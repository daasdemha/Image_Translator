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
    public partial class UsingCamraView : ContentPage
    {
        public UsingCamraView()
        {
            InitializeComponent();
            BindingContext = new HomeViewModel();
        }
    }
}