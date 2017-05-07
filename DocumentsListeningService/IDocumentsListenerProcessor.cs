using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsListeningService
{
    public interface IDocumentsListenerProcessor
    {
        Task ProceedDocument(string fileName);
    }
}
