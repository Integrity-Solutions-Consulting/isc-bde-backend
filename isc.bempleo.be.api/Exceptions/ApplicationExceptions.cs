using isc.bempleo.be.domain.Exceptions;
using isc.bempleo.be.domain.Models.DTOs.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Serilog;
using System.Text.Json;

namespace isc.bempleo.be.api.Exceptions
{
    public static class ApplicationExceptions
    {
        public static IApplicationBuilder ConfigureExcepcionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var error = exceptionHandlerPathFeature?.Error;

                    int statusCode = 500;
                    int errorCode = 500;
                    string message = "Ocurrió un error interno.";
                    string stackTrace = null;

                    if (error != null)
                    {
                        if (error is BaseCustomException customEx)
                        {
                            errorCode = customEx.Code;
                            message = customEx.Message;
                            stackTrace = customEx.StackTrace;
                            statusCode = errorCode == 0 ? 500 : errorCode;

                            // Ajuste de statusCode si se usa ClientFaultException
                            if (error is ClientFaultException)
                            {
                                statusCode = 400;
                            }
                        }
                        else
                        {
                            // Excepciones no personalizadas
                            message = error.Message;
                            stackTrace = error.StackTrace;
                            statusCode = 500;
                        }
                    }

                    context.Response.StatusCode = statusCode;

                    var response = new ErrorResponseDto
                    {
                        Code = statusCode,
                        Message = message,
                        Error = new List<ErrorData>
                {
                    new ErrorData
                    {
                        Code = errorCode,
                        Message = stackTrace ?? message
                    }
                },
                        TraceId = context?.TraceIdentifier?.Split(":")[0].ToLower() ?? "no-traceid"
                    };

                    Log.Error("{Proceso} {errorCode} {errorMessage}", "ExceptionHandler", statusCode, message);

                    var json = JsonSerializer.Serialize(response);

                    await context.Response.WriteAsync(json);
                    await context.Response.Body.FlushAsync();
                });
            });

            return app;
        }
    }
}
