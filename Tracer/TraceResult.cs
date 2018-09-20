﻿using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace Tracer
{
    /// <summary>
    /// Class to control process of method tracing 
    /// </summary>
    public class TraceResult
    {
        private List<TraceThread> traceThreads;
        public List<TraceThread> TraceThreads { get => traceThreads; private set => traceThreads = value; }

        /// <summary>
        /// Start Analyzing given method
        /// </summary>
        /// <param name="methodBase">method to analyze</param>
        internal void AnalyzeMethod(MethodBase methodBase)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            TraceMethod traceMethod = new TraceMethod(methodBase);

            int index = -1;
            if (TraceThreads.Count > 0)
            {
                index = TraceThreads.FindIndex(x => x.Id == threadId);
            }
            if (index >= 0)
            {
                TraceThreads[index].AddMethod(traceMethod);
            }
            else
            {
                TraceThread thread = new TraceThread(threadId);
                thread.AddMethod(traceMethod);
                TraceThreads.Add(thread);
            }
        }
        /// <summary>
        /// Stops counting Execution time (Completes analyze method)
        /// </summary>
        internal void StopAnalyseMethod()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            TraceThreads.Find(x => x.Id == threadId)?.StopMethodTrace();
        }

        public TraceResult()
        {
            traceThreads = new List<TraceThread>();
        }
    }
}
