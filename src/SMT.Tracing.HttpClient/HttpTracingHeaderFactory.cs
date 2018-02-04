using SMT.Tracing.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SMT.Tracing.HttpClient
{
    public static class HttpTracingHeaderFactory
    {
        private const string TRACING_HEADER_KEY = "smt-tracing-trace-id";

        public static KeyValuePair<string, string>[] GenerateTracingHeaders()
        {
            var trace = Tracer.GetCurrent();
            if (trace != null)
            {
                return new KeyValuePair<string, string>[]
                {
                    new KeyValuePair<string, string>(TRACING_HEADER_KEY, trace.TraceId),
                };
            }

            return new KeyValuePair<string, string>[] { };
        }

        public static void AttachTracingHeadersToRequest(HttpRequest request)
        {
            var tracingHeaders = GenerateTracingHeaders();
            foreach (var tracingHeader in tracingHeaders)
            {
                request.Headers.Add(tracingHeader.Key, tracingHeader.Value);
            }
        }
    }
}
