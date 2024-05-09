using Microsoft.EntityFrameworkCore;
using talentsoftReclutamiento.Models;

namespace talentsoftReclutamiento.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

       public DbSet<Candidate> candidate {  get; set; }

        public DbSet<Offer> offer { get; set; }

    }
}
