using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tracer
{
    internal class TraceMethod
    {
        string classname;
        string methodname;
        long executionTime;
        private readonly Stopwatch stopwatch;
        List<TraceMethod> methodslist;

        internal List<TraceMethod> SubMethods { get => methodslist;}
        internal long ExecutionTime { get => executionTime;}
        internal string Methodname { get => methodname;}
        internal string Classname { get => classname;}

        internal TraceMethod(string newmethodname, string newclassname)
        {
            classname = newclassname;
            methodname = newmethodname;
            executionTime = 0;

            stopwatch = new Stopwatch();
            methodslist = new List<TraceMethod>();
        }

        internal TraceMethod(MethodBase method)
        {
            methodname = method.Name;
            classname = method.DeclaringType?.Name;
            executionTime = 0;

            stopwatch = new Stopwatch();
            methodslist = new List<TraceMethod>();
        }

        internal void AddSubmethod(TraceMethod method)
        {
            SubMethods.Add(method);
        }

        internal void StartTrace()
        {
            stopwatch.Start();
        }

        internal void StopTrace()
        {
            stopwatch.Stop();
            executionTime = stopwatch.ElapsedMilliseconds;
        }
    }
}
