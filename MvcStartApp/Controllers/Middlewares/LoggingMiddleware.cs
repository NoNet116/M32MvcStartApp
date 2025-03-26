using Azure.Core;
using MvcStartApp.Models.Db;
using MvcStartApp.Models.Repositories;

namespace MvcStartApp.Controllers.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context,ILogRepository _logrepo)
        {
            // Список расширений файлов, которые НЕ нужно логировать
            var ignoredExtensions = new[] { ".css", ".js", ".png", ".jpg", ".jpeg", ".gif", ".ico", ".svg", ".woff", ".woff2", ".ttf", ".eot" };

            // Получаем путь запроса
            var requestPath = context.Request.Path.Value;

            // Проверяем, нужно ли игнорировать логирование
            if (ignoredExtensions.Any(ext => requestPath.EndsWith(ext, StringComparison.OrdinalIgnoreCase)))
            {
                await _next(context); // Просто передаем запрос дальше
                return;
            }

            // Получаем полный URL посещённой страницы
            var fullUrl = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}{context.Request.QueryString} [{context.Connection.RemoteIpAddress}]";

            // Формируем строку лога
            var logEntry = $"{DateTime.Now}: {context.Request.Method} {context.Request.Path} {context.Connection.RemoteIpAddress}";

            var request = new Models.Db.Request
            {
                Date = DateTime.Now,
                Id = Guid.NewGuid(),
                Url = fullUrl
            };
            await _logrepo.AddLog(request);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(fullUrl);

            // Логирование в консоль
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(logEntry);
            Console.ForegroundColor = default;

            // Передаем запрос дальше по конвейеру
            await _next(context);
        }
    }
}
