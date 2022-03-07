using Company.API.DataLayer.DTO;
using Microsoft.EntityFrameworkCore;

namespace Company.API.DataLayer.DataContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Drink> Drinks { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
