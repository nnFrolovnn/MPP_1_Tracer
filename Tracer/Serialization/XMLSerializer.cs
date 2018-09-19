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
            return document.ToString();
        }

        private XElement MethodResultToXml(TraceMethod method)
        {
            XElement res = new XElement("method");
            res.Add(new XAttribute("class", method.Class));
            res.Add(new XAttribute("name", method.Method));
            res.Add(new XAttribute("time", method.ExecutionTime));

            foreach (var innerMethod in method.SubMethods)
            {
                res.Add(MethodResultToXml(innerMethod));
            }

            return res;
        }

        public XMLSerializer()
        {

        }
    }
}
