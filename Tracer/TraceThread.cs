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

        public bool AddMethod (TraceMethod method)
        {
            if (methodsstack.Count == 0)
            {
                methodslist.Add(method);
            }
            else
            {

            }

            return true;
        }

        public TraceThread()
        {
            id = 0;
            executiontime = 0;
            methodslist = new List<TraceMethod>();
            methodsstack = new Stack<TraceMethod>();
        }
    }
}
