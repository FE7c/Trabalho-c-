using Comidas.Models;
using Microsoft.EntityFrameworkCore;

namespace Comidas.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Comida> Comidas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=Comidas.sqlite;Cache=Shared");
    }
}