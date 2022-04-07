using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ImagesTranslator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        private MediaFile photo;
       
        public DetailsPage(MediaFile photo, OcrResult result)
        {
            InitializeComponent();
            
            this.photo = photo;
            Image.Source = ImageSource.FromStream(() =>
            {
                var a = photo.GetStream();
                return a;
            });
            foreach (var region in result.Regions)
            {
               
                foreach (var line in region.Lines)
                {
                   

                    foreach (var word in line.Words)
                    {
                        LblResult.Text += Convert.ToString(word.Text)+" ";
                        
                        
                    }
                    LblResult.Text += "\n";
                }
                
            }
          
        }
        

        private async void ShareNote_Clicked(object sender, EventArgs e)
        {
            if (LblResult != null)
            {
                await Share.RequestAsync(new ShareTextRequest
                {

                    Text = LblResult.Text,
                    Title = "Notes"
                });
            }
        }
    }
}