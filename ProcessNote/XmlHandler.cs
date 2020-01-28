using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;
using System.Collections;

namespace ProcessNote
{
    class XmlHandler 
    {
        public static void XmlWriter(ProcLister procList)
        {
            //ProcLister listOfProcs = new ProcLister(RunProc.processCreate());

            XmlSerializer serializer = new XmlSerializer(typeof(ProcLister));
            using (TextWriter writer = new StreamWriter("comment.xml"))
            {

                
                    serializer.Serialize(writer, procList);
                
            }
            


        }
        public static ProcLister XmlReader() {
            XmlSerializer serializer =new  XmlSerializer(typeof(ProcLister));
            ProcLister listOfProcs;
            using (Stream reader = new FileStream("comment.xml",FileMode.Open))
            {
                listOfProcs = (ProcLister)serializer.Deserialize(reader);
            }
            return listOfProcs;
        }
        
        }
        
    }

