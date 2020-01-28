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
            int[] wordLength = new int[] { 0, 0, 0, 0 };
            foreach(RunProc proc in procList.ListedProcs)
            {
                if (proc.ProcId.ToString().Length > wordLength[0])
                    wordLength[0] = proc.ProcId.ToString().Length;
                if (proc.ProcName.Length > wordLength[1])
                    wordLength[1] = proc.ProcName.Length;
                if (proc.RunningTime.ToString().Length > wordLength[2])
                    wordLength[2] = proc.RunningTime.ToString().Length;
                try
                {
                    if (proc.Comment.Length > wordLength[3])
                        wordLength[3] = proc.Comment.Length;
                }
                catch (NullReferenceException)
                {
                    if (wordLength[3] < 1) {
                        wordLength[3] = 1;
                            }
                    
                }
                
            }
            foreach (RunProc proc in procList.ListedProcs)
            {
                
                Console.WriteLine(string.Format("|{0}|{1}|{2}|{3}|", centeredString(proc.ProcId.ToString(),wordLength[0]),centeredString(proc.ProcName,wordLength[1]),centeredString(proc.RunningTime.ToString(),wordLength[2]),centeredString(proc.Comment,wordLength[3])));
                //Console.WriteLine($"{{0,{wordLength[0]}}} {{1,{wordLength[1]}}} {{2,{wordLength[2]}}} {{3,{wordLength[3]}}}", proc.ProcId,proc.ProcName,proc.RunningTime,proc.Comment);
                   //Console.WriteLine(string.Format($"{{0,{wordLength[0]}}} {2,{3}} {4,{5}} {6,{7}}", proc.ProcId.ToString(), proc.ProcName, wordLength[1], proc.RunningTime.ToString(), wordLength[2], proc.Comment, wordLength[3]));
                //Console.WriteLine(proc.ProcId + " " + proc.ProcName + " " + proc.RunningTime + " " + proc.Comment);
            }

        }
        private static string centeredString(string s, int width)
        {
            try
            {
                int leftPadding = (width - s.Length) / 2;
                int rightPadding = width - s.Length - leftPadding;
                return new string(' ', leftPadding) + s + new string(' ', rightPadding);
            }
            catch (System.NullReferenceException)
            {
                return new string(' ', (width-1)/2) + " " + new string(' ',(width-1)/2);
            }
        }
        public ProcLister procCommenter(ProcLister listOfProcs, string id, string comment)
        {
            foreach (RunProc proc in listOfProcs.ListedProcs)
            {
                if (proc.ProcId.ToString().Equals(id))
                {
                    proc.Comment = comment;
                }

            }
            return listOfProcs;
        }
        public bool procSearch(ProcLister listOfProcs, string id)
        {
            foreach (RunProc proc in listOfProcs.ListedProcs)
            {
                if (proc.ProcId.ToString().Equals(id))
                {
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static int procCounter(ProcLister listOfProcs)
        {
            int count = 0;
            foreach(RunProc item in listOfProcs.ListedProcs)
            {
                count++;
            }
            return count;
        }
    }
}
