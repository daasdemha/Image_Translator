using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ImagesTranslator.Utility
{
    public interface IAzureService
    {
        Task<OcrResult> GetOCRResult(MediaFile file);
    }
}
