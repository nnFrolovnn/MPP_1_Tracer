﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Serialization
{
    public interface ISerialize
    {
        string Serialize(TraceResult result);
    }
}
