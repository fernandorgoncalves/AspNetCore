using Cibergestion.Controllers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cibergestion.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<funcionarios>funcionarios { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
