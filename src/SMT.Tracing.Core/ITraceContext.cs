using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMT.Tracing.Core
{
    public interface ITraceContext
    {
        Trace GetCurrentTraceFromContext();
        void SetCurrentTraceToContext(Trace traceContext);
    }
}
