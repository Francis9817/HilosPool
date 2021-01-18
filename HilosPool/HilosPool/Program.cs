using System;
using System.IO;
using System.Threading;

namespace HilosPool
{
    class Program
    {
        const string path = @"C:\Users\Francisco\Desktop\Hilos\";
        static void Main(string[] args)
        {
            for (int i = 0; i < 50; i++)
            {
                ThreadPool.QueueUserWorkItem(Create, i);
            }
            while (ThreadPool.PendingWorkItemCount > 0) ;

        }
        static void Create(object data)
        {
            int i = (int)data;
            using (var sw = new StreamWriter(path + i + "txt"))
            {
                sw.WriteLine("Hola soy el hilo " + Thread.CurrentThread.ManagedThreadId);
            }
            Console.WriteLine("Hola soy el hilo " + Thread.CurrentThread.ManagedThreadId);
        }
    }
}
