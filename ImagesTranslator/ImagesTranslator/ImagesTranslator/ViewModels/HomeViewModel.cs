using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using System.Windows.Input;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using ImagesTranslator.Views;
using System.IO;
using ImagesTranslator.Utility;

namespace ImagesTranslator.ViewModels
{
  
    public class HomeViewModel : INotifyPropertyChanged
    {
        public OcrResult analysis { get; set; }
        public ICommand takePhoto { get; }
        public ICommand pickPhoto { get; }

        private readonly IAzureService iAzureService;


        public HomeViewModel(IAzureService iAzureService) //inject the service
        {
            takePhoto = new Command(async () => await takePhotoFromCam());

            pickPhoto = new Command(async () => await PickPhotoFromStorage());
            this.iAzureService = iAzureService;
        }

         async Task PickPhotoFromStorage()
        {
            MediaFile photo;

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                return;
            }
            var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Small
            });


            if (file == null)
                return;
            if (file != null)
            {
                try
                {

                    // key1 987e9c1f4b6f4109b9c675474df0f0c8
                    // key 2 e74d8ddd25c44572ba3dbfdf4d88357d
                    // end point https://daasdemha1.cognitiveservices.azure.com/

                    //key2


                    analysis = await iAzureService.GetOCRResult(file);

                    await Application.Current.MainPage.Navigation.PushModalAsync(new DetailsPage(file, analysis));

                }
                catch (Exception ex)
                {
                    var a = ex.Message;
                    // Isbusy = false;
                   // await Application.Current.MainPage.Navigation.PushPopupAsync(new AlertPage("E", ex.Message));
                }
             //   await Application.Current.MainPage.Navigation.PushAsync(new DetailsPage(file));

            }


        }
        async Task takePhotoFromCam()
        {
            
            try
            {
                
                // 1. Add camera logic.
                await CrossMedia.Current.Initialize();

                MediaFile photo;
                if (CrossMedia.Current.IsCameraAvailable)
                {
                    photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                    {
                        Directory = "Receipts",
                        Name = "Receipt"
                    });
                }
                else
                {
                    photo = await CrossMedia.Current.PickPhotoAsync();
                }

                if (photo == null)
                {
                    PrintStatus("Photo was null :(");
                    return;
                }


                // 2. Add  OCR logic.
                DetectResult text;
                try
                {

                    // key 1:  ba7e3c22098e4b2c9958e47afe653478
                    // key 1:  3bd735e019a94808bf4e72bc5c016445
                    // End Point:  https://readmyimage.cognitiveservices.azure.com/

                       analysis = await iAzureService.GetOCRResult(photo);

                    await Application.Current.MainPage.Navigation.PushAsync(new DetailsPage(photo, analysis));
                }
                catch (Exception e)
                {
                    var a = e.Message;
                   // return e.Message;
                }


             
              
            }
            catch (Exception ex)
            {
                await (Application.Current?.MainPage?.DisplayAlert("Error",
                    $"Something bad happened: {ex.Message}", "OK") ??
                    Task.FromResult(true));

                PrintStatus(string.Format("ERROR: {0}", ex.Message));

            }
            finally
            {
                
            }

        }

        public void PrintStatus(string helloWorld)
        {
            if (helloWorld == null)
                throw new ArgumentNullException(nameof(helloWorld));

          //  WriteLine(helloWorld);
        }


        #region check azure server Test

        public async Task<string> CheckAzureServer(string path)
        {
            string result = string.Empty;
            try
            {
               using (var client = new ComputerVisionClient(new ApiKeyServiceClientCredentials("987e9c1f4b6f4109b9c675474df0f0c8")) { Endpoint = "https://daasdemha1.cognitiveservices.azure.com/" })
                {
                    FileStream file = new FileStream(path, FileMode.Open);

                    analysis = await client.RecognizePrintedTextInStreamAsync(true, file);

                    foreach (var region in analysis.Regions)
                    {

                        foreach (var line in region.Lines)
                        {


                            foreach (var word in line.Words)
                            {
                                result += Convert.ToString(word.Text) + " ";


                            }
                        }

                    }

                };
                return result;
            }
         
            catch (Exception e)
            {
                return result;
            }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        bool busy;
       

    }
}
