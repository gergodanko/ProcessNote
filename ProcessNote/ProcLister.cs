using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProcessNote
{
    [Serializable]
      public class ProcLister
    {
         public List<RunProc> ListedProcs;
        public ProcLister(List<RunProc> listed)
        {
            ListedProcs = listed;
        }
        public ProcLister()
        {

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
