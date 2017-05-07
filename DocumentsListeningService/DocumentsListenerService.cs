using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRecognition;
using Topshelf;

namespace DocumentsListeningService
{
    public class DocumentsListenerService : ServiceControl
    {
        private readonly DocumentsListener _documentsListener;
        private static string InputDirectory => ConfigurationManager.AppSettings["InputDirectory"];
        public DocumentsListenerService()
        {
            var documentCreator = new TextDocumentCreator();
            var imageTextReader = new ImagePrintingTextReader();
            var documentsListenerProcessor = new ImageTextReaderProcessor(documentCreator, imageTextReader);
            _documentsListener = new DocumentsListener(InputDirectory, documentsListenerProcessor);   
        }

        public bool Start(HostControl hostControl)
        {
            _documentsListener.Start();
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            _documentsListener.Stop();
            return true;
        }
    }
}
