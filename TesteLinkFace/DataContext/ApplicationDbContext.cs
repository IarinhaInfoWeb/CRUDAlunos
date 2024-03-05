using Microsoft.EntityFrameworkCore;
using TesteLinkFace.Models;

namespace TesteLinkFace.DataContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<AlunosModel> Alunos { get; set; }
    }
}
