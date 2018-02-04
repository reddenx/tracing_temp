using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMT.Tracing.Core
{
    public class Trace
    {
        public readonly string TraceId;

        internal Trace(string traceId)
        {
            TraceId = traceId;
        }
    }
}
