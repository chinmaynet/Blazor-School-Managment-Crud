using Microsoft.EntityFrameworkCore;
using SchooleManagment.Shared.Model;

namespace SchooleManagment.Server.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<student> Students { get; set; }
    }
}
