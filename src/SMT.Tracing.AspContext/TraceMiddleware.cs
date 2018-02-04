using Microsoft.Owin;
using SMT.Tracing.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMT.Tracing.AspContext
{
    public class TraceMiddleware : OwinMiddleware
    {
        private const string TRACING_HEADER_KEY = "smt-tracing-trace-id";

        public TraceMiddleware(OwinMiddleware next) : base(next)
        {
        }

        public override async Task Invoke(IOwinContext context)
        {
            //if there's a tracing header, continue the trace
            Trace trace = null;
            if (context.Request.Headers.ContainsKey(TRACING_HEADER_KEY))
            {
                var traceId = context.Request.Headers.Get(TRACING_HEADER_KEY);
                if (!string.IsNullOrWhiteSpace(traceId))
                {
                    trace = new Trace(traceId);
                    Tracer.ContinueTrace(trace);
                }
            }
            
            if(trace == null)
            {
                Tracer.StartNewTrace();
                trace = Tracer.GetCurrent();
            }

            await Next.Invoke(context);
        }
    }
}
