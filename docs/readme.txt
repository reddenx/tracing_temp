purpose:
distributed tracing in a system with many incompatible contexts and connections.

goals:
trace context in many application types: application, iis hosted service, eventually non c# environments
propagate traces to other applications
dependency mapping, tracking dependencies through services and applications.
annotation of log messages and data onto traces

artifacts:
context package: a package that allows the application to retrieve, create, and annotate tracing contexts.
client packages: packages that support tracing propagation to other applications/services. (http,soap, etc).
trace sink: a runnable server that hosts an endpoint for tracing to be logged.






Context packages:
- core, a common interface to the tracing context, contains the ability to talk with the trace sink.
- http, iis hosted and web context enabled applications.
- integrated, applications without context

Client packages:
- rest sender client that appends headers on rest calls.
- OWIN middle-ware that pairs with rest sender client and places trace info into the core context.
- WCF client that pairs with OWIN middle-ware server
- SOAP client that adds parameters to message.
- SOAP server package that interprets the messages built by the SOAP client.

Deployable Server (tracing sink):
- executable that opens an endpoint for incoming traces (UDP).
- IIS hosted API that provides an endpoint for incoming traces (HTTP/UDP).