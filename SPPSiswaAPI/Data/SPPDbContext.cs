using Microsoft.EntityFrameworkCore;
using SPPSiswaAPI.Models;

namespace SPPSiswaAPI.Data
{
    public class SPPDbContext : DbContext
    {
        public SPPDbContext(DbContextOptions options) : base(options) {}

        public DbSet<Student> Students { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<SPP> SPP { get; set; }
    }
}
