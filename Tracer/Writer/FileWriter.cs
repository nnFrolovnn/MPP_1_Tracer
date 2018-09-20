using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer
{
    public class FileWriter : IWriter
    {
        string fileName;

        public void OutPut(string source)
        {
            File.WriteAllText(fileName, source);
        }

        public FileWriter(string nfile)
        {
            fileName = nfile;
        }
    }
}
