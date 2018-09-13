using System;
using System.Diagnostics;
using System.Reflection;

namespace Tracer
{
    public class SomeTracer : ITracer
    {
        private TraceResult traceResult;
        private bool isTracing;

        public bool IsTracing { get => isTracing; }

        public SomeTracer()
        {
            traceResult = new TraceResult();
            isTracing = false;
        }

        public TraceResult GetTraceResult()
        {
            if (isTracing)
            {
                return null;
            }
            else
            {
                return traceResult;
            }
        }

        public void StartTrace()
        {
            StackFrame frame = new StackFrame(1);
            MethodBase method = frame.GetMethod();

            traceResult.AnalyzeMethod(method);
        }

        public void StopTrace()
        {
            throw new NotImplementedException();
        }
    }
}
