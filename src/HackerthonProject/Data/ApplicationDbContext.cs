using HackerthonProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection;

namespace HackerthonProject.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContext) : base(dbContext)
        {

        }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Advocate> Advocates { get; set; }

        //public DbSet<Links> Links { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

           /* builder.Entity<Advocate>()
                .HasOne(p => p.Company)
                .WithMany(a => a.Advocates)
                .HasForeignKey(a => a.CompanyId);*/
        }
    }
}
