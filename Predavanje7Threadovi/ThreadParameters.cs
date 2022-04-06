using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Predavanje7Threadovi
{
    class ThreadParameters
    {
        static void Main()
        {
            //preko lambde
            Thread t = new Thread(() => Print("Hello from t!"));
            t.Start();

            //preko delegata i metode Start
            //public delegate void ParameterizedThreadStart(object obj); -> delegat
            //ograničenje je da prima samo jedan parametar i da je tipa object (cast)
            Thread t2 = new Thread(Print);
            t.Start("Hello from t!");
        }

        static void Print(string message)
        {
            Console.WriteLine(message);
        }

        static void Print(object messageObj)
        {
            string message = (string)messageObj; 
            Console.WriteLine(message);
        }
    }
}

