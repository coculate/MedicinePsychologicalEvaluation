using Microsoft.EntityFrameworkCore;

namespace MedicinePsychologicalEvaluation.Models
{
    public class MyDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=.;Initial Catalog=MedicinePE;uid=sa;pwd=sa;");
        }

        public DbSet<Medicine_Evaluation>? Medicine_Evaluation { get; set; }

        public DbSet<Medicine_Project>? Medicine_Project { get; set; }

        public DbSet<Medicine_Record>? Medicine_Record { get; set; }

        public DbSet<Medicine_Users>? Medicine_Users { get; set; }

    }
}
