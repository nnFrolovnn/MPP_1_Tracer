using System;
using System.IO;

namespace Tracer
{
    public class ConsoleWriter : IWriter
    {
        public void OutPut(string source)
        {
            Console.WriteLine(source);
        }
    }
}
