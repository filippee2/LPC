using Microsoft.EntityFrameworkCore;

namespace AvaliaçãoG1.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 

        }

        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<PlanoDeSaude> PlanosDeSaude { get; set; }
    }
}