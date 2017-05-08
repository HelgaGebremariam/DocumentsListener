using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentsListeningService;
using Topshelf;

namespace DocumentsListeningServiceRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<DocumentsListenerService>();
                x.SetServiceName("DocumentsListener");
                x.SetDisplayName("Documents Recognizer");
                x.StartAutomatically();
                x.EnableServiceRecovery(
                    r => r.RestartService(1).RestartService(1));
                x.RunAsLocalService();
            });
        }
    }
}
