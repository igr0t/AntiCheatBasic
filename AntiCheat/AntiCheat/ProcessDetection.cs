using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace AntiCheat
{



    internal class ProcessDetection
    {
        public static bool detected;
        public static List<string> currentlyRunning = new List<string>();
        public static string[] suspiciousNames = { "Cheat", "Debugger", "x64dbg", "IDA PRO", "Cheat Engine", "cheatengine", "x32dbg", "x64dbg (32bits)" };
        public static string ignore = AppDomain.CurrentDomain.FriendlyName; // Lista de Permitidos

        public static void UpdateProcList()
        {
            Process[] running = Process.GetProcesses();
            foreach (Process proc in running)
            {
                currentlyRunning.Add(proc.ProcessName);

            }
        }
         public static void FindProcess()
        {
            foreach(string procName in currentlyRunning)
            {
                for(int i = 0; i < suspiciousNames.Length; i++)
                {
                    if (procName != ignore)
                    {
                        if (procName.Contains(suspiciousNames[i]))
                        {
                            detected = true;
                            Console.WriteLine("Detectado:" + suspiciousNames[i]);
                            return;
                        }
                    }

                }
            }
                    }

    }
    
}
