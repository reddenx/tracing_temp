using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMT.Tracing.Core
{
    public static class Tracer
    {
        private static ITraceContext TraceContext;

        public static void Register(ITraceContext traceContext)
        {
            TraceContext = traceContext;
        }

        public static Trace GetCurrent()
        {
            return TraceContext.GetCurrentTraceFromContext();
        }

        public static void StartNewTrace()
        {
            var newTrace = new Trace(Guid.NewGuid().ToString("N"));
            TraceContext.SetCurrentTraceToContext(newTrace);
        }

        public static void ContinueTrace(Trace trace)
        {
            TraceContext.SetCurrentTraceToContext(trace);
        }
    }
}
