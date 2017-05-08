using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using NLog;

namespace DocumentsListeningService
{
    public class DocumentsListener : IDisposable
    {
        private readonly FileSystemWatcher _fileSystemWatcher;
        private readonly IDocumentsListenerProcessor _documentsListenerProcessor;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public DocumentsListener(string folderToListenPath, IDocumentsListenerProcessor documentsListenerProcessor)
        {
            _fileSystemWatcher = new FileSystemWatcher(folderToListenPath) {
                NotifyFilter = NotifyFilters.FileName
            };
            _documentsListenerProcessor = documentsListenerProcessor;
            _fileSystemWatcher.Created += OnDocumentAdded;
            _logger.Info("Listener created. Folder: " + folderToListenPath);
        }

        public void Start()
        {
            _fileSystemWatcher.EnableRaisingEvents = true;
            _logger.Info("Listener has been started");
        }

        public void Stop()
        {
            _fileSystemWatcher.EnableRaisingEvents = false;
            _logger.Info("Listener has been stopped");
        }

        private async void OnDocumentAdded(object sender, FileSystemEventArgs e)
        {
            _logger.Info("New document added: " + e.FullPath);
            await _documentsListenerProcessor.ProceedDocument(e.FullPath);
        }

        public void Dispose()
        {
            _fileSystemWatcher?.Dispose();
        }
    }
}
