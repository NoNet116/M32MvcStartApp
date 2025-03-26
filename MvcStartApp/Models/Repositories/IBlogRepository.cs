using MvcStartApp.Models.Db;

namespace MvcStartApp.Models.Repositories
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
        Task<IResult> Register(User user);
        Task<User[]> GetUsers();
    }
}
