using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predavanje4_Delegati
{
    public delegate void Notify();  // delegat

    public class EventExample
    {
        public event Notify ProcessCompleted; // događaj

        public void StartProcess()
        {
            Console.WriteLine("Process Started!");
            //imamo neku obradu
            OnProcessCompleted();
        }

        protected void OnProcessCompleted() 
        {
            //ako se netko pretplatio pošalji obavijest
            ProcessCompleted?.Invoke();
        }
    }
}
