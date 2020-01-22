using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ProcessNote
{
    class Menu


    {
        public void showMenu(string[] menupoints)
        {
            int index = 1;
            foreach (string point in menupoints)
            {
                Console.WriteLine("(" + index + ") " + point);
                index++;
            }
            Console.WriteLine("(0) Exit Program");
        }
        public void start()
        {
            string[] menupoints = new string[]
            {
                "Running processes",
                "Realtime running processes",
                "Saving data to file"
            };


            while (true)
            {
                showMenu(menupoints);
                Console.WriteLine("Type in your choice: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine("Currently running processes: ");
                            ProcLister listOfProcs = new ProcLister(RunProc.processCreate());
                            listOfProcs.procPrinter(listOfProcs);
                            Console.WriteLine("Press a button to exit!");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    case 2:
                        {
                            while (true)
                            {
                                Console.Clear();
                                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.X) break;
                                Console.WriteLine("Press x to exit. Currently running processes: ");
                                ProcLister listOfProcs = new ProcLister(RunProc.processCreate());
                                listOfProcs.procPrinter(listOfProcs);
                                Thread.Sleep(5000);
                                

                            }
                            break;

                        }
                    case 3:
                        {
                            Console.Clear();
                            ProcLister listOfProcs = new ProcLister(RunProc.processCreate());
                            XmlHandler.Xmlanyad(listOfProcs);
                            break;
                        }
                    

                        }
                }
            }
        }
    }

