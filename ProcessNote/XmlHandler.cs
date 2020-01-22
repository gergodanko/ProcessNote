using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;


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
           /* string inputId = "8328";
            string inputName = "TuneIn";
            string inputComment = "SAnyi";
            string xmlString = System.IO.File.ReadAllText("comment.xml");
            XDocument doc = XDocument.Parse(xmlString);
            XElement id = doc.Root.Element(inputId);
            XElement name = doc.Root.Element(inputName);
            XComment comm = new XComment(inputComment);
            id.AddBeforeSelf(comm);
            */


        }
    }
}
