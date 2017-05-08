using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsListeningService.Helpers
{
    public static class PathHelper
    {
        public static string GetUniqueFileName(string filePath, string fileName, string extension)
        {
            var resultFileName = Path.ChangeExtension(fileName, extension);
            var counter = 0;
            while (File.Exists(Path.Combine(filePath, resultFileName)))
            {
                resultFileName = Path.GetFileNameWithoutExtension(resultFileName) + counter +
                               Path.GetExtension(resultFileName);
                counter++;
            }
            return Path.Combine(filePath, resultFileName);
        }
    }
}
