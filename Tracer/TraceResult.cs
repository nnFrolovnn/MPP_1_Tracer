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
            //get parent method
            StackFrame parentFrame = new StackFrame(3);
            MethodBase parentMethod = parentFrame.GetMethod();

            int threadId = Thread.CurrentThread.ManagedThreadId;

            int index = ThreadResults.FindIndex(x => x.Id == threadId);
            if (index >= 0)
            {
                TraceMethod parentTraceMethod = new TraceMethod(parentMethod);
                TraceMethod childTraceMethod = new TraceMethod(methodBase);
                ThreadResults[index].AddMethod(childTraceMethod, parentTraceMethod);
            }
            else
            {
               //no thread id
            }


            return true;
        }
    }
}
