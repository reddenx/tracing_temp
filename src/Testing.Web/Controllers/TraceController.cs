using SMT.Tracing.Core;
using SMT.Tracing.HttpClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Testing.Web.Controllers
{
    [RoutePrefix("api/trace")]
    public class TraceController : ApiController
    {
        [Route("test")]
        public object CreateNewTrace()
        {
            var currentTrace = Tracer.GetCurrent();
            var forwardingHeaders = HttpTracingHeaderFactory.GenerateTracingHeaders();

            return new
            {
                currentTrace,
                forwardingHeaders,
            };
        }
    }
}