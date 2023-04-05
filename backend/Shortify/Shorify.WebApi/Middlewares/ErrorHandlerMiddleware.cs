using System.Text;

namespace Shorify.WebApi.Middlewares;

public class ErrorHandlerMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
		try
		{
			await next(context);
		}
		catch (Exception ex)
		{
            var response = context.Response;
            response.StatusCode = ex switch
            {
                NullReferenceException => (int)System.Net.HttpStatusCode.NotFound,
                _ => (int)System.Net.HttpStatusCode.BadRequest,
                
            };

            var result = System.Text.Json.JsonSerializer.Serialize(new { message = ex.Message });
            await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes(result));
        }
    }
}
