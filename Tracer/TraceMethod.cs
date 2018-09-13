using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tracer
{
    public class TraceMethod
    {
        string classname;
        string methodname;
        long executionTime;
        List<TraceMethod> methodslist;

        public List<TraceMethod> Methodslist { get => methodslist;}
        public long ExecutionTime { get => executionTime; set => executionTime = value; }
        public string Methodname { get => methodname;}
        public string Classname { get => classname;}

        public TraceMethod(string newmethodname, string newclassname)
        {
            classname = newclassname;
            methodname = newmethodname;
            ExecutionTime = 0;

            methodslist = new List<TraceMethod>();
        }

        public TraceMethod(MethodBase method)
        {
            classname = method.Name;
            methodname = method.DeclaringType?.Name;
            ExecutionTime = 0;

            methodslist = new List<TraceMethod>();
        }

    }
}
