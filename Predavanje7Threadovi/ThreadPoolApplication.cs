using System;
using System.Threading;

namespace ThreadPoolApplication
{
    class ThreadPoolApplication
    {
        static void Main()
        {
            //poziv metode - koristi thread pool umjesto klasičnog threada
            ThreadPool.QueueUserWorkItem(Go);
            ThreadPool.QueueUserWorkItem(Go, 123);
            Console.ReadLine();
        }

        static void Go(object data)   
        {
            Console.WriteLine("Hello from the thread pool! " + data);
        }

       //Hello from the thread pool!
       //Hello from the thread pool! 123
    }
}


