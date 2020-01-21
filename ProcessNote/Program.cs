using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;

namespace ProcessNote
{
    class Program
    {
        static void Main(string[] args)
        {
            t1.Start();

            t2.Start();
            t1.Join();
            t2.Join();

        }
        static Thread t1 = new Thread(
                    new ThreadStart(() =>
                    {
                        SystemUsage.getCurrentCpuUsage();
                    }));

        static Thread t2 = new Thread(
                            new ThreadStart(() => {
                                List<string> process = new List<string>();
                                while (true)
                                {
                                    if (!process.Any())
                                    {
                                        process = processRuntime();
                                        foreach (string row in process)
                                        {
                                            Console.WriteLine(row);
                                        }

                                    }
                                    else
                                    {
                                        foreach (string row in process)
                                        {
                                            Console.WriteLine(row);
                                        }
                                    }
                                    Thread.Sleep(800);
                                }
                        //trigger camera
                    }));

  
        public static List<string> processRuntime() { 
        while (true)
             {
                 Process[] processlist = Process.GetProcesses();
                List<string> asd = new List<string>();
                 foreach (Process theprocess in processlist)
                 {
                    TimeSpan runtime;
                    try
                    {
                        runtime = DateTime.Now - theprocess.StartTime;
                    }
                    catch (Win32Exception ex)
                    {
                        // Ignore processes that give "access denied" error.
                        if (ex.NativeErrorCode == 5)
                            continue;
                        throw;
                    }
                    asd.Add("Process:"+ theprocess.ProcessName + "ID: "+theprocess.Id + "Running since: "+runtime);
                   
                 }
                return asd;
                 
                
            }

        }
    }}
       
        /*static Thread t3 = new Thread(new ThreadStart(() =>
        {
            while (true)
            {
                Console.WriteLine(SystemUptime.UpTime);
                Thread.Sleep(1000);
            }
        }
            ));
        public static void dataPrinter()
        {
            while (true)
            {
                CpuUsage.getCurrentCpuUsage();
                Thread.Sleep(1000);
                Console.WriteLine(RamUsage.getAvaibleRam());
                
            }
        }
        
    }
}*/
