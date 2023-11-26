// SessionMiddleware.cs
using Microsoft.AspNetCore.Http;
using DoughAssistantBackend.Interfaces;
using System.Threading.Tasks;

        // https://exceptionnotfound.net/middleware-in-asp-net-6-custom-middleware-classes/
public class SessionMiddleware
{
    private readonly RequestDelegate _next;

    public SessionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IAuthenticationRepository authenticationRepository)
    {
        var sessionKey = context.Request.Cookies["SessionKey"];

        if (string.IsNullOrEmpty(sessionKey) || !authenticationRepository.SessionExists(sessionKey))
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsync("No session found with session key");
            return;
        }

        await _next(context);
    }
}
