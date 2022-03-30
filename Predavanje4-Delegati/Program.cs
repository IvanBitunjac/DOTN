using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predavanje4_Delegati
{
  
    public class Program
    {
        public delegate void MyDelegate(string msg);
        public delegate void MyMulticastDelegate(string msg);

        


        static void Main(string[] args)
        {
            
        //####################### SINGLE DELEGATE ###############################
        //dodijeljivanje metode delagatu
          MyDelegate delTest = new MyDelegate(ClassA.MethodA);
            //ili kraće
            MyDelegate del = ClassA.MethodA;

            //pozivanje metode preko delegata
            del("Hello World");

            //delegatu možemo dodijeliti neku novu metodu
            del = ClassB.MethodB;
            del("Hello World");

            //proslijeđivanje delegata metodi
            InvokeDelegate(del);


            //####################### MULTICAST DELEGATE ###############################
            MyMulticastDelegate del1 = ClassA.MethodA;
            MyMulticastDelegate del2 = ClassB.MethodB;

            MyMulticastDelegate multicast = del1 + del2; // spaja del1 i del2
            multicast("Hello World");

            multicast = multicast - del2; // mičemo del2
            multicast("Hello World");

            multicast -= del1; // mičemo del1 - delegat ostaje prazan baca grešku
            //multicast("Hello World");

            //####################### EVENT ###############################
            EventExample bl = new EventExample();
            bl.ProcessCompleted += bl_ProcessCompleted; // pretplati se na događaj
            bl.StartProcess();

            Console.ReadKey();

        }

        public static void bl_ProcessCompleted()
        {
            Console.WriteLine("Process Completed!");
        }

        static void InvokeDelegate(MyDelegate del) 
        {
            del("Hello World");
        }
    }

    public class ClassA
    {
        public static void MethodA(string message)
        {
            Console.WriteLine("Called ClassA.MethodA() with parameter: " + message);
        }
    }

    public class ClassB
    {
        public static void MethodB(string message)
        {
            Console.WriteLine("Called ClassB.MethodB() with parameter: " + message);
        }
    }
}
