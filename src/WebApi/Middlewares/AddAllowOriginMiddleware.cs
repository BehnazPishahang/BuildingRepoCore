namespace Building.Core.WebApi.Middlewares;

public class AddAllowOriginMiddleware
{
    private readonly RequestDelegate _next;

    public AddAllowOriginMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    public async Task Invoke(HttpContext context)
    {
        context.Request.Headers.Add("Access-Control-Allow-Origin", "*");
        await _next(context);
    }
}