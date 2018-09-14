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

        public List<TraceMethod> Methodslist { get => methodslist; }
        public long Executiontime { get => executiontime; set => executiontime = value; }
        public long Id { get => id; set => id = value; }


        /// <summary>
        /// Add method to List of Tracing methods
        /// </summary>
        /// <param name="method">method to trace</param>
        public void AddMethod (TraceMethod method)
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

        public TraceThread(long newid)
        {
            id = newid;
            executiontime = 0;
            methodslist = new List<TraceMethod>();
            methodsstack = new Stack<TraceMethod>();
        }

        public void StopMethodTrace()
        {
            methodsstack.Pop().StopTrace();
        }
    }
}
