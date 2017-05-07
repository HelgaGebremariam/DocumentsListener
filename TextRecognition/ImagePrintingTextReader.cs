﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;
using TextRecognition.Interface;

namespace TextRecognition
{
    public class ImagePrintingTextReader : IImageTextReader
    {
        private static string ComputerVisionApiKey => ConfigurationManager.AppSettings["ComputerVisionApiKey"];
        private static string ComputerVisionApiEndpoint => ConfigurationManager.AppSettings["ComputerVisionApiEndpoint"];

        private readonly VisionServiceClient _visionServiceClient;

        public ImagePrintingTextReader()
        {
            _visionServiceClient = new VisionServiceClient(ComputerVisionApiKey, ComputerVisionApiEndpoint);
        }

        public async Task<OcrResults> ReadTextFromImage(string imageFilePath)
        {
            using (Stream imageFileStream = File.OpenRead(imageFilePath))
            {
                imageFileStream.Seek(0, SeekOrigin.Begin);
                return await _visionServiceClient.RecognizeTextAsync(imageFileStream);
            }
        }
    }
}