using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace DocumentsListeningService
{
    public class DocumentsListener : IDisposable
    {
        private readonly FileSystemWatcher _fileSystemWatcher;
        private readonly IDocumentsListenerProcessor _documentsListenerProcessor;
        public DocumentsListener(string folderToListenPath, IDocumentsListenerProcessor documentsListenerProcessor)
        {
            _fileSystemWatcher = new FileSystemWatcher(folderToListenPath) {
                NotifyFilter = NotifyFilters.FileName
            };
            _documentsListenerProcessor = documentsListenerProcessor;
            _fileSystemWatcher.Created += OnDocumentAdded;
        }

        public void Start()
        {
            _fileSystemWatcher.EnableRaisingEvents = true;
        }

        public void Stop()
        {
            _fileSystemWatcher.EnableRaisingEvents = false;
        }

        private async void OnDocumentAdded(object sender, FileSystemEventArgs e)
        {
            await _documentsListenerProcessor.ProceedDocument(e.FullPath);
        }

        public void Dispose()
        {
            _fileSystemWatcher?.Dispose();
        }
    }
}
