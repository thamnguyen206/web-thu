using System.Text.RegularExpressions;

namespace lison7.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        // Khớp /Book/Detail/{id} hoặc /Books/Details/{id} (id có thể âm)
        private static readonly Regex DetailPath = new(
            @"^/books?/details?/(?<id>-?\d+)/?$",
            RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var method = context.Request.Method;
            var path = context.Request.Path.ToString();

            // Chức năng 1: log request
            Console.WriteLine($"[{time}] Method: {method} - Path: {path}");

            // Chức năng 3: chặn id <= 0
            var match = DetailPath.Match(path);
            if (match.Success
                && long.TryParse(match.Groups["id"].Value, out var id)
                && id <= 0)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "text/plain; charset=utf-8";
                await context.Response.WriteAsync("Book id không hợp lệ");
                Console.WriteLine($"Status Code: {context.Response.StatusCode}");
                return;
            }

            await _next(context);

            // Chức năng 2: log status code
            Console.WriteLine($"Status Code: {context.Response.StatusCode}");
        }
    }
}
