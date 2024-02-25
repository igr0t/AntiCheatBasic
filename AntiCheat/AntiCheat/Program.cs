using System;
using System.Threading;

namespace AntiCheat
{
    class Program
    {
        private static Thread thread;
        static void Main(string[] args)
        {
            thread = new Thread(ConsoleThread);
            thread.Name = "ConsoleThread";
            thread.Start();
            Console.ReadLine();
        }
        public static void ConsoleThread()
        {
            while (true)
            {
                ProcessDetection.UpdateProcList();
                ProcessDetection.FindProcess();
                Thread.Sleep(3000);
            }
        }
    }
}