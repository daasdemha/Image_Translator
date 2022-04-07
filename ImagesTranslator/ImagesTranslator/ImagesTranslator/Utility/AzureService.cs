using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ImagesTranslator.Utility
{
    public class AzureService: IAzureService
    {
        private OcrResult analysis;
        public async Task<OcrResult> GetOCRResult(MediaFile file)
        {
            using (var client = new ComputerVisionClient(new ApiKeyServiceClientCredentials("987e9c1f4b6f4109b9c675474df0f0c8")) { Endpoint = "https://daasdemha1.cognitiveservices.azure.com/" })
            {
                analysis = await client.RecognizePrintedTextInStreamAsync(true, file.GetStream());
            };

            return analysis;
        }
    }
}
