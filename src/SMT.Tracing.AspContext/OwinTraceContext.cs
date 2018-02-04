using Microsoft.Owin;
using SMT.Tracing.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Owin;

namespace SMT.Tracing.AspContext
{
    public class OwinTraceContext : ITraceContext
    {
        private static readonly string HTTP_CONTEXT_KEY = $"smt-tracing-context-key-{Assembly.GetAssembly(typeof(OwinTraceContext))?.GetName()?.Version?.ToString() ?? "UNVERSIONED"}";

        public Trace GetCurrentTraceFromContext()
        {
            if (System.Web.HttpContext.Current.Request.RequestContext.RouteData.Values.ContainsKey(HTTP_CONTEXT_KEY))
            {
                return System.Web.HttpContext.Current.Request.RequestContext.RouteData.Values[HTTP_CONTEXT_KEY] as Trace;
            }
            else
            {
                return null;
            }
        }

        public void SetCurrentTraceToContext(Trace trace)
        {
            System.Web.HttpContext.Current.Request.RequestContext.RouteData.Values.Add(HTTP_CONTEXT_KEY, trace);
        }
    }
}
