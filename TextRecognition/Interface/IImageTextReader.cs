using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Vision.Contract;

namespace TextRecognition.Interface
{
    public interface IImageTextReader
    {
        Task<OcrResults> ReadTextFromImage(string imagePath);
    }
}
