using MvcStartApp.Models.Db;

namespace MvcStartApp.Models.Repositories
{
    public interface ILogRepository
    {
        Task AddLog(Request request);
        Task<Request[]> GetRequests();
    }
}
