using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcStartApp.Models.Db;

namespace MvcStartApp.Models.Repositories
{
    public class LogRepository : ILogRepository
    {

        // ссылка на контекст
        private readonly MvcAppContext _context;

        // Метод-конструктор для инициализации
        public LogRepository(MvcAppContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task AddLog(Request request)
        {
           await _context.Requests.AddAsync(request);

            // Сохранение изменений
            await _context.SaveChangesAsync();
        }

        public async Task<Request[]> GetRequests()
        {
            // Получим всех активных пользователей
            return await _context.Requests.ToArrayAsync();
        }
    }
}
