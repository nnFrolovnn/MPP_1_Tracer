using System;
using System.Diagnostics;
using System.Reflection;
using Tracer.Serialization;

namespace Tracer
{
    public class SomeTracer : ITracer
    {
        private TraceResult traceResult;
        private int isTracing;

        public bool IsTracing { get { return (isTracing != 0) ? true : false; } }

        public SomeTracer()
        {
            traceResult = new TraceResult();
            isTracing = 0;
        }

        public TraceResult GetTraceResult()
        {
            return (isTracing != 0) ? null : traceResult;
        }

        public void StartTrace()
        {
            StackFrame frame = new StackFrame(1);
            MethodBase method = frame.GetMethod();

            isTracing++;
            traceResult.AnalyzeMethod(method);
        }

        public void StopTrace()
        {
            traceResult.StopAnalyseMethod();
            isTracing--;
        }
    }
}
