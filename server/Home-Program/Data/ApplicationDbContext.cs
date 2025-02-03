using Home_Program.Model;
using Microsoft.EntityFrameworkCore;

namespace Home_Program.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<ProgramIdea> ProgramIdea { get; set; }
    }
}
