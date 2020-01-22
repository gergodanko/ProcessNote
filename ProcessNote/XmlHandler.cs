using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;


namespace ProcessNote
{
    class XmlHandler
    {
        public static void Xmlanyad(ProcLister procList)
        {
            //ProcLister listOfProcs = new ProcLister(RunProc.processCreate());

            XmlSerializer serializer = new XmlSerializer(typeof(ProcLister));
            using (TextWriter writer = new StreamWriter("comment.xml"))
            {

                
                    serializer.Serialize(writer, procList);
                
            }
        }
    }
}
