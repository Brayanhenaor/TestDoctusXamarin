using DoctusTest.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctusTest.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Tip> Tips { get; set; }

        public DatabaseContext()
        {
            SQLitePCL.Batteries_V2.Init();
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite($"Filename={Constant.DatabasePath}");
        }
    }
}
