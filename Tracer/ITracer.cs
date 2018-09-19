using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer
{
    public interface ITracer
    {
        /// <summary>
        /// Start measuring the execution time for methods
        /// </summary>
        void StartTrace();
        
        /// <summary>
        /// Stop measuring the execution time for methods
        /// </summary>
        void StopTrace();
        
        /// <summary>
        /// Results of work. Call after StopTrace()
        /// </summary>
        /// <returns>
        /// Value contains the method, class names, execution time
        /// </returns>
        TraceResult GetTraceResult();
    }
}
