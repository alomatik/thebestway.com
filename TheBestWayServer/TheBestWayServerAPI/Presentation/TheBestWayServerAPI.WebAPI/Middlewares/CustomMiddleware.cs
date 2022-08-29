namespace TheBestWayServerAPI.WebAPI.Middlewares
{
    public class CustomMiddleware
    {
        RequestDelegate _next;
        
        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //operation..
            Console.WriteLine("Hello, I am custom middleware.");
            await _next.Invoke(httpContext);
            Console.WriteLine("Goodbye, I am custom middleware");
        }

    }
}
