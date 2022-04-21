using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MovieShopMVC.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MovieShopExceptionsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<MovieShopExceptionsMiddleware> _logger;

        public MovieShopExceptionsMiddleware(RequestDelegate next, ILogger<MovieShopExceptionsMiddleware> logger)
        {
            _next = next;
            _logger = logger;

        }

        public async Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation("Inside the ExceptionMiddleware");
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                // catch the exception and 
                // od the exception logic
                // redirect to the error page
                //throw;
                var exceptionDetials = new {
                    Messahe = ex.Message,
                    Stack = ex.StackTrace,
                    ExceptionDatetime = DateTime.UtcNow,
                    ExceptionType = ex.GetType(),
                    Path = httpContext.Request.Path,
                    HttpMethod = httpContext.Request.Method,
                    User = httpContext.User.Identity.IsAuthenticated ? httpContext.User.Identity.Name: null
                    // email
                    // user id
                };
                // save this information to the Lof Files, Text Files, Json Files, Database
                // System.IO
                // .NET Core builtin DI, Logging, ILogger
                // any 3rd party libarries that implement this ILogger 

                // Send email to dev team
                // Redirect to user friendly page 
                _logger.LogError("Exception Happened, handle here");
                //
                httpContext.Response.Redirect("/home/error");
                await Task.CompletedTask;
            }

            //return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MovieShopExceptionsMiddlewareExtensions
    {
        public static IApplicationBuilder UseMovieShopExceptionsMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MovieShopExceptionsMiddleware>();
        }
    }
}
