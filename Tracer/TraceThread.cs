using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tracer
{
    /// <summary>
    /// Contains list of methods in one thread
    /// </summary>
    public class TraceThread
    {
        private long id;
        private long executiontime;
        List<TraceMethod> methodslist;
        Stack<TraceMethod> methodsstack;

        internal List<TraceMethod> Methodslist { get => methodslist; }
        internal long Executiontime { get => executiontime; set => executiontime = value; }
        internal long Id { get => id; private set => id = value; }


        /// <summary>
        /// Add method to List of Tracing methods
        /// </summary>
        /// <param name="method">method to trace</param>
        internal void AddMethod (TraceMethod method)
        {
            if (methodsstack.Count == 0)
            {
                methodslist.Add(method);
            }
            else
            {
                methodsstack.Peek().AddSubmethod(method);
            }

            methodsstack.Push(method);
            method.StartTrace();
        }

        internal TraceThread(long newid)
        {
            id = newid;
            executiontime = 0;
            methodslist = new List<TraceMethod>();
            methodsstack = new Stack<TraceMethod>();
        }

        internal void StopMethodTrace()
        {
            methodsstack.Pop().StopTrace();
        }
    }
}
