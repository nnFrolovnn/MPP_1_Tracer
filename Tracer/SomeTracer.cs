using System.Diagnostics;
using System.Reflection;

namespace Tracer
{
    public class SomeTracer : ITracer
    {
        private TraceResult traceResult;
        private int isTracing;
        object ob;
        public bool IsTracing { get { return (isTracing != 0) ? true : false; } }

        public SomeTracer()
        {
            traceResult = new TraceResult();
            isTracing = 0;
            ob = new object();
        }

        public TraceResult GetTraceResult()
        {
            return (isTracing > 0) ? null : traceResult;
        }

        public void StartTrace()
        {
            StackFrame frame = new StackFrame(1);
            MethodBase method = frame.GetMethod();
            lock (ob)
            {
                isTracing++;
            }          
            traceResult.AnalyzeMethod(method);
        }

        public void StopTrace()
        {
            traceResult.StopAnalyseMethod();
            lock (ob)
            {
                isTracing--;
            }
        }
    }
}
