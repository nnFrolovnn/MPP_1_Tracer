using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tracer.Serialization
{
    public class XMLSerializer : ISerialize
    {
        string fileName;
        bool writeInFile;

        public string Serialize(TraceResult result)
        {
            XDocument document = new XDocument();
            XElement root = new XElement("root");

            foreach (var thread in result.TraceThreads)
            {
                var threadElement = new XElement("thread");
                threadElement.Add(new XAttribute("id", thread.Id));
                threadElement.Add(new XAttribute("time", thread.Executiontime));

                foreach (var method in thread.Methodslist)
                {
                    threadElement.Add(MethodResultToXml(method));
                }

                root.Add(threadElement);
            }
            
            document.Add(root);
            if (writeInFile)
            {
                WriteResult(document);
            }
            return document.ToString();
        }

        private XElement MethodResultToXml(TraceMethod method)
        {
            XElement res = new XElement("method");
            res.Add(new XAttribute("class", method.Classname));
            res.Add(new XAttribute("name", method.Methodname));
            res.Add(new XAttribute("time", method.ExecutionTime));

            foreach (var innerMethod in method.SubMethods)
            {
                res.Add(MethodResultToXml(innerMethod));
            }

            return res;
        }

        private void WriteResult(XDocument document)
        {
            try
            {
                using (FileStream xmlfilestream = File.Create(fileName))
                {
                    using (StreamWriter streamWriter = new StreamWriter(xmlfilestream))
                    {
                        streamWriter.WriteLine(document.ToString());
                    }
                }
            }
            catch { };
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="nfileName"> if nfileName = "", file won't create</param>
        public XMLSerializer(string nfileName)
        {
            fileName = nfileName;
            if (fileName == "")
            {
                writeInFile = false;                
            }
        }
    }
}
