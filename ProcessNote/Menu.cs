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
                "System usage",
                "Saving running processes to file",
                "Saving data to file with comments",
                "Read data from file"

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
                            ProcLister listFromFile = new ProcLister();
                            listFromFile = XmlHandler.XmlReader();
                            foreach(RunProc proc1 in listOfProcs.ListedProcs)
                            {
                                foreach(RunProc proc2 in listFromFile.ListedProcs)
                                {
                                    if(proc1.ProcId.Equals(proc2.ProcId) && proc1.ProcName.Equals(proc2.ProcName)){
                                        proc1.Comment = proc2.Comment;
                                    }
                                }
                            }
                            listOfProcs.procPrinter(listOfProcs);
                            Console.WriteLine("Press enter to exit!");
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
                                ProcLister listFromFile = new ProcLister();
                                listFromFile = XmlHandler.XmlReader();
                                foreach (RunProc proc1 in listOfProcs.ListedProcs)
                                {
                                    foreach (RunProc proc2 in listFromFile.ListedProcs)
                                    {
                                        if (proc1.ProcId.Equals(proc2.ProcId) && proc1.ProcName.Equals(proc2.ProcName))
                                        {
                                            proc1.Comment = proc2.Comment;
                                        }
                                    }
                                }
                                listOfProcs.procPrinter(listOfProcs);
                                Thread.Sleep(5000);


                            }
                            break;

                        }
                    case 3:
                        {
                            Console.Clear();
                            
                            Console.WriteLine("Press x to exit. ");
                            SystemUsage.getCurrentCpuUsage();

                            break;

                        }
                    case 4:
                        {
                            Console.Clear();
                            ProcLister listOfProcs = new ProcLister(RunProc.processCreate());
                            XmlHandler.XmlWriter(listOfProcs);
                            Console.WriteLine("Data saved!");
                            break;
                        }
                    case 5: {
                            Console.Clear();
                            ProcLister asd = new ProcLister(RunProc.processCreate());
                            asd.procPrinter(asd);
                            
                                while (true)
                                {
                                char writeChoice;
                                Console.WriteLine("Do you want to write a comment y/n ?");
                                writeChoice = char.Parse(Console.ReadLine());
                                if (writeChoice == 'y' || writeChoice == 'Y')
                                {
                                    string processId;
                                    Console.WriteLine("Which process do you want to comment on? Type in process id: ");
                                    processId = Console.ReadLine();
                                    if(asd.procSearch(asd, processId) == false)
                                    {
                                        Console.WriteLine("There is no process running with this ID.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Type in your comment: ");
                                        string comment = Console.ReadLine();
                                        asd.procCommenter(asd, processId,comment);

                                    }

                                }
                                else if (writeChoice == 'n' || writeChoice == 'N')
                                {
                                    
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Answer with 'y' or 'n' character!");
                                }

                            }
                            
                            
                            XmlHandler.XmlWriter(asd);
                            Console.Clear();
                            break;
                        }
                    case 6:
                        {
                            Console.Clear();
                            
                            Console.WriteLine();
                            ProcLister asd = XmlHandler.XmlReader();
                            asd.procPrinter(asd);
                            Console.WriteLine("Press enter to exit!");
                            Console.ReadLine();
                            
                            Console.Clear();
                            break;
                        }

                    case 0:
                        {
                            Environment.Exit(0);
                            break;
                        }


                }
            }
        }
    }
}
