using ImagesTranslator.Models;
using ImagesTranslator.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ImagesTranslator.ViewModels
{
    public class CarouselPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<CarouselModel> _Carousel;

        private string _pageTitle;
        public CarouselPageViewModel()
        {

            _Carousel = new ObservableCollection<CarouselModel>();
            _Carousel.Add(new CarouselModel { Title = "Capture.", ImagePath = "image1.png" ,Description="Scan your peace of paper and get digital text on single click."});
            _Carousel.Add(new CarouselModel { Title = "Share.", ImagePath = "image2.png", Description= "Share in social media the scanned text." });
            
         
        }

        public ObservableCollection<CarouselModel> Carousels
        {
            get
            {
                return _Carousel;
            }
            set
            {
                if (_Carousel != value)
                {
                    _Carousel = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Carousels"));
                }
            }
        }

        public Command NavigateSignin
        {
            get
            {
                return new Command(() =>
                {

                    Application.Current.MainPage = new NavigationPage(new LoginPage());


                });
            }
        }
       
        private void OnPropertyChanged(PropertyChangedEventArgs eventArgs)
        {
            PropertyChanged?.Invoke(this, eventArgs);
        }
    }
}
