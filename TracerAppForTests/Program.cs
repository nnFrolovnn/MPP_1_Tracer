using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer;
namespace TracerAppForTests
{
    class Program
    {
        static void Main(string[] args)
        {
            SomeTracer tracer = new SomeTracer();
            tracer.StartTrace();
            System.Threading.Thread.Sleep(1000);
            tracer.StopTrace();
        }
    }
}
