﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRecognition.Interface;
using DocumentsListeningService.Helpers;
using NLog;

namespace DocumentsListeningService
{
    public class ImageTextReaderProcessor : IDocumentsListenerProcessor
    {
        private static string OutputDirectory => ConfigurationManager.AppSettings["OutputDirectory"];

        private readonly IDocumentCreator _documentCreator;
        private readonly IImageTextReader _imageTextReader;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public ImageTextReaderProcessor(IDocumentCreator documentCreator, IImageTextReader imageTextReader)
        {
            _documentCreator = documentCreator;
            _imageTextReader = imageTextReader;
        }

        public async Task ProceedDocument(string fileName)
        {
            var recognitionResults = await _imageTextReader.ReadTextFromImage(fileName);
            var outputFileName = PathHelper.GetUniqueFileName(OutputDirectory, Path.GetFileName(fileName), "txt");
            _documentCreator.SaveAsDocument(recognitionResults, outputFileName);
            _logger.Info("Saved text file: " + outputFileName);
        }
    }
}
