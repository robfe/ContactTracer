# ContactTracer
.net core MVC web app for allowing people to register their attendance at an event, to make contact tracing easy in case of reported infection

Code refers to ContactTracerNoAuth because there was an old version which mucked around with asp.net identity, but that wasn't necessary for the prototype


## Running locally

Install .net core 3.1 SDK from https://dotnet.microsoft.com/download/dotnet-core/3.1

execute `dotnet run`

Should work on windows or linux, uses a sqlite database: `app.db` in the main project folder

