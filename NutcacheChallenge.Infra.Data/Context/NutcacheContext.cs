using Microsoft.EntityFrameworkCore;
using NutcacheChallenge.Domain.Models;

namespace NutcacheChallenge.Infra.Data.Context
{
    public class NutcacheContext : DbContext
    {
        public NutcacheContext(DbContextOptions<NutcacheContext> dbContextOptions) : base(dbContextOptions)
        {
            Database.Migrate();
        }

        DbSet<Employee> Employees { get; set; }
    }
}
