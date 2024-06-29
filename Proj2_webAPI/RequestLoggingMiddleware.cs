namespace Proj2_webAPI
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            // Логируем начало обработки запроса
            _logger.LogInformation($"Request: {context.Request.Method} {context.Request.Path}");

            // Продолжаем обработку запроса в следующем middleware или контроллере
            await _next(context);

            // Логируем завершение обработки запроса
            _logger.LogInformation($"Request completed: {context.Request.Method} {context.Request.Path}");
        }
    }
}
