using Entity.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DataAccess.Concrete.EntityFramework
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=sql5110.site4now.net; Database=db_aa1d14_smartsystem; Integrated Security=false; user id= db_aa1d14_smartsystem_admin; password=Murad.123");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
    }
}
