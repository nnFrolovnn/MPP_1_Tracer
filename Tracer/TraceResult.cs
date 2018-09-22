using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace Tracer
{
    /// <summary>
    /// Class to control process of method tracing 
    /// </summary>
    public class TraceResult
    {
        private ConcurrentDictionary<int, TraceThread> traceThreads;
        public ConcurrentDictionary<int , TraceThread> TraceThreads { get => traceThreads; private set => traceThreads = value; }

        /// <summary>
        /// Start Analyzing given method
        /// </summary>
        /// <param name="methodBase">method to analyze</param>
        internal void AnalyzeMethod(MethodBase methodBase)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            TraceMethod traceMethod = new TraceMethod(methodBase);

            if (TraceThreads.ContainsKey(threadId))
            {
                TraceThreads[threadId].StartTrace(traceMethod);
            }
            else
            {
                TraceThread threadResult = new TraceThread(threadId);
                TraceThreads.GetOrAdd(threadId, threadResult);
                threadResult.StartTrace(traceMethod);
            }
        }
        /// <summary>
        /// Stops counting Execution time (Completes analyze method)
        /// </summary>
        internal void StopAnalyseMethod()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            TraceThreads[threadId]?.StopMethodTrace();
        }

        public TraceResult()
        {
            traceThreads = new ConcurrentDictionary<int, TraceThread>();
        }
    }
}
