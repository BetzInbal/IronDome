namespace IronDome.Middleware
{
    public class SimpleMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            //Console.WriteLine( $"request : {DateTime.Now}");
            var path = context.Request.Path;
            //Console.WriteLine($"Path : {path}");
            await _next(context);
            var res = context.Response.StatusCode;
            //Console.WriteLine($"request : {res}");
        }
    }
}

