using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Predavanje7Threadovi
{
    class ThreadTest
    {
        static void Main()
        {
            //Konstruktoru Thread klase proslijedimo ThreadStart delegat
            //potpis delegata -> public delegate void ThreadStart();
            Thread t = new Thread(new ThreadStart(Go)); //dodijelimo delegatu metodu Go
            //kraći način -> Thread t = new Thread(Go); 

            t.Start();   // Pokrenemo thread (pokrenut će se metoda Go)
            Go();        // Simultano pokrećemo metodu Go u glavnom threadu
        }

        static void Go()
        {
            Console.WriteLine("hello!");
        }

        //rezultat će biti dvaput ispisana riječ hello
    }
}


