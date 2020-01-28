using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace ProcessNote
{
    class SystemUsage
    {
        PerformanceCounter cpuCounter;

        public static void getCurrentCpuUsage()
        {
            var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            while (true)
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.X) break;
                var RamCounter = new PerformanceCounter("Memory", "Available MBytes");
                Console.WriteLine(RamCounter.NextValue() + "MB");
                Console.WriteLine(cpuCounter.NextValue() + "%");
                Thread.Sleep(1000);
                Console.Clear();
                
            }
                

        }
    }
}
