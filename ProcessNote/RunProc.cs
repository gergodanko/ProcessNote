using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Xml;

namespace ProcessNote
{
    public class RunProc
    {
        public int ProcId { get; set; }
        public string ProcName { get; set; }
        [XmlIgnore]
        public TimeSpan RunningTime { get { return XmlConvert.ToTimeSpan(ReadTimeSpan); } set { ReadTimeSpan = XmlConvert.ToString(value); } }
        [XmlElement("RunningTime")]
        [Browsable(false)]
        public string ReadTimeSpan { get; set; }
        

        


        public RunProc(int id, string name,TimeSpan running)
        {
            ProcId = id;
            ProcName = name;
            RunningTime = running;
        }
        public RunProc()
        {

        }

        public static List<RunProc> processCreate()
        {
            while (true)
            {
                Process[] processlist = Process.GetProcesses();
                List<RunProc> runningProcs= new List<RunProc>();
                foreach (Process theprocess in processlist)
                {
                    TimeSpan runtime;
                    try
                    {
                        runtime = DateTime.Now - theprocess.StartTime;
                        RunProc runningProcess = new RunProc(theprocess.Id, theprocess.ProcessName, runtime);
                        runningProcs.Add(runningProcess);
                    }
                    catch (Exception ex)
                    {

                        if (ex is Win32Exception /*&& ex.NativeErrorCode == 5 */|| ex is InvalidOperationException)
                        {
                            continue;
                            throw;
                        }
                    }
                    
                    
                }
                return runningProcs;
                


            }
        }
    }
}
