using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Vision.Contract;
using TextRecognition.Interface;

namespace TextRecognition
{
    public class ImageHandwritingTextReader : IImageTextReader
    {
        public Task<OcrResults> ReadTextFromImage(string imagePath)
        {
            throw new NotImplementedException();
        }
    }
}
