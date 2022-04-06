using System;
using System.Diagnostics;
using System.ServiceProcess;
using System.Threading;

namespace Predavanje7Servis
{
    public partial class ADOTN : ServiceBase
    {
        //https://www.c-sharpcorner.com/article/create-windows-services-in-c-sharp/

        EventLog log;
        // Kreiraj flag za upravljanje servisom
        bool aktivan;
        public ADOTN()
        {
            InitializeComponent();
            // Kreiraj novi EventLog što jwe u biti pisač u windows log
            log = new EventLog();
            if (!EventLog.SourceExists("DOTN Predavanje")) // Odvojiti ćemo naš log od ostalih
            {
                EventLog.CreateEventSource("DOTN Predavanje", "Application");
            }
            log.Source = "DOTN Predavanje";
            log.Log = "Application";
        }

        protected override void OnStart(string[] args)
        {
            WaitCallback delegat = nestoRadim; // Ovo je naš kod za izvođenje u drugoj niti
            aktivan = true; // Može se početi izvoditi
            if (ThreadPool.QueueUserWorkItem(delegat))
            {
                // Sve OK u redu smo, izvodimo se
                log.WriteEntry($"Krenuli smo u {DateTime.Now.ToLongTimeString()}!");
            }
        }

        protected override void OnStop()
        { // Evidentiraj kraj u logu
            log.WriteEntry($"Zaustavili smo se u {DateTime.Now.ToLongTimeString()}!");
            // Zaustavi se nestoRadim 
            aktivan = false;
        }

        void nestoRadim(object nista)
        {
            // Nalazimo se u drugoj niti
            //for (int i = 0; i < 10; i++)
            int i = 0;
            while (aktivan) // Dok mu ne spustimo zastavicu on će vrtiti petlju
            {
                i++;
                Thread.Sleep(2500);
                log.WriteEntry($"Prolaz petlje broj: {i} u {DateTime.Now.ToLongTimeString()}");
            }
        }
    }
}
