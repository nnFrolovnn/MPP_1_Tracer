using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Tracer.Serialization
{
    public class JSONSerializer : ISerialize
    {
        public string Serialize(TraceResult result)
        {
            string output = JsonConvert.SerializeObject(result.TraceThreads, Formatting.Indented);
            return output;
        }
    }
}
