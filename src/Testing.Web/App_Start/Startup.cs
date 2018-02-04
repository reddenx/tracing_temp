using Microsoft.Owin;
using Owin;
using SMT.Tracing.AspContext;
using SMT.Tracing.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartupAttribute(typeof(Testing.Web.App_Start.Startup))]

namespace Testing.Web.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Tracer.Register(new OwinTraceContext());
            app.Use<TraceMiddleware>();
        }
    }
}