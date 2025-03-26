using Microsoft.EntityFrameworkCore;
using MvcStartApp.Models.Db;

namespace MvcStartApp.Models
{
    public class MvcAppContext: DbContext
    {
        /// Ссылка на таблицу Users
        public DbSet<User> Users { get; set; }

        /// Ссылка на таблицу UserPosts
        public DbSet<UserPost> UserPosts { get; set; }

        public DbSet<Request> Requests { get; set; }

        // Логика взаимодействия с таблицами в БД
        public MvcAppContext(DbContextOptions<MvcAppContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
