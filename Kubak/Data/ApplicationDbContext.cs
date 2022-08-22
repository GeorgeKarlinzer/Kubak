using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Kubak.Models;

namespace Kubak.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Instruction> Instructions { get; set; }
        public DbSet<InstructionCategory> InstructionCategories { get; set; }
    }
}