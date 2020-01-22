using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessNote
{
    class ProcLister
    {
        public List<RunProc> ListedProcs { get; set; }
        public ProcLister(List<RunProc> listed)
        {
            ListedProcs = listed;
        }
        public void procPrinter(ProcLister procList)
        {
            //ProcLister procList = new ProcLister(RunProc.processCreate());
            foreach (RunProc proc in procList.ListedProcs)
            {
                Console.WriteLine(proc.ProcId + " " + proc.ProcName + " " + proc.RunningTime);
            }
            
        }
    }
}
