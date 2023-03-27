
public class TimeMiddleware
{
    //propiedad que nos va ayudar a invocar el middleware que sigue.
    readonly RequestDelegate next;

    public TimeMiddleware(RequestDelegate nextRequest)
    {
        next = nextRequest;
    }

    //Siempre se debe declarar
    public async Task Invoke(HttpContext context)
    {
        await next(context);

        if (context.Request.Query.Any(p => p.Key == "time"))
        {
            await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());

        }

        // await next(context);

    }
}

public static class TimeMiddlewareExtension
{
    public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder build)
    {

        return build.UseMiddleware<TimeMiddleware>();
    }
}