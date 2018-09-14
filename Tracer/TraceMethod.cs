using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private readonly Stopwatch stopwatch;
        List<TraceMethod> methodslist;

        public List<TraceMethod> SubMethods { get => methodslist;}
        public long ExecutionTime { get => executionTime;}
        public string Methodname { get => methodname;}
        public string Classname { get => classname;}

        public TraceMethod(string newmethodname, string newclassname)
        {
            classname = newclassname;
            methodname = newmethodname;
            executionTime = 0;

            stopwatch = new Stopwatch();
            methodslist = new List<TraceMethod>();
        }

        public TraceMethod(MethodBase method)
        {
            methodname = method.Name;
            classname = method.DeclaringType?.Name;
            executionTime = 0;

            stopwatch = new Stopwatch();
            methodslist = new List<TraceMethod>();
        }

        public void AddSubmethod(TraceMethod method)
        {
            SubMethods.Add(method);
        }

        public void StartTrace()
        {
            stopwatch.Start();
        }

        public void StopTrace()
        {
            stopwatch.Stop();
            executionTime = stopwatch.ElapsedMilliseconds;
        }
    }
}
