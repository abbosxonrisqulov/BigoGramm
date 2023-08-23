using BigoGramm.Models;
using BigoGramm.Service.Exceptions;

namespace BigoGramm.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        public readonly RequestDelegate request;
        public readonly ILogger logger;
        public ExceptionHandlerMiddleware(RequestDelegate request, ILogger<ExceptionHandlerMiddleware> logger)
        {
            this.request = request;
            this.logger = logger;

        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.request.Invoke(context);
            }
            catch (NotFoundException ex) 
            {
                context.Response.StatusCode = ex.StatusCode;
                await context.Response.WriteAsJsonAsync(new Response
                {
                    StatusCode = ex.StatusCode,
                    Message = ex.Message,
                });
            }
            catch (AlreadyExistException ex)
            {
                await context.Response.WriteAsJsonAsync(new Response
                {
                    StatusCode = ex.StatusCode,
                    Message = ex.Message,
                }); 
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.ToString());
                await context.Response.WriteAsJsonAsync(new Response
                {
                    StatusCode = 500,
                    Message = ex.Message,
                });
            }
        }
    }
}
