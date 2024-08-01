using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace ApiNotes.Middlewares
{
    public static  class ApiExeptionMiddlewareExtesions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {

            //Configurando o Midleware de tratamento de exceções
            app.UseExceptionHandler(appError =>
            {
                //Especifica o que fazer com uma exceção não tratada
                appError.Run(async context =>
                {
                    //Códugoi de status
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    //Tipo do conteudo da nossa resposta
                    context.Response.ContentType = "application/json";

                    //Instanciando uma 
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    //Caso tenha dado uma exceção, eu instancio a minha classe ErrorDetails
                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message,
                            Trace = contextFeature.Error.StackTrace
                        }.ToString());
                    }
                });
            });
        }

    }
}

