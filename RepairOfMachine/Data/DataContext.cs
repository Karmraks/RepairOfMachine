using Microsoft.EntityFrameworkCore;
using RepairOfMachine.Models.Entities;

namespace RepairOfMachine.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        DbSet<User> Users { get; set; }
        DbSet<News> News { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
