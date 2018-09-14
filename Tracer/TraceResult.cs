using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tracer
{
    public class TraceResult
    {
        public List<TraceThread> ThreadResults { get; }

        public bool AnalyzeMethod(MethodBase methodBase)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;

            int index = ThreadResults.FindIndex(x => x.Id == threadId);
            if (index >= 0)
            {
                TraceMethod childTraceMethod = new TraceMethod(methodBase);
                ThreadResults[index].AddMethod(childTraceMethod);
            }
            else
            {
               //no thread id
            }


            return true;
        }
    }
}
