using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Vision.Contract;
using TextRecognition.Interface;

namespace TextRecognition
{
    public class TextDocumentCreator : IDocumentCreator
    {
        public void SaveAsDocument(OcrResults text, string filePath)
        {
            if (filePath == null) return;

            if (text?.Regions == null) return;

            using (var streamWriter = File.CreateText(filePath))
            {
                foreach (var item in text.Regions)
                {
                    foreach (var line in item.Lines)
                    {
                        foreach (var word in line.Words)
                        {
                            streamWriter.Write(word.Text);
                            streamWriter.Write(" ");
                        }

                        streamWriter.WriteLine();
                    }

                    streamWriter.WriteLine();
                }
            }
        }
    }
}
