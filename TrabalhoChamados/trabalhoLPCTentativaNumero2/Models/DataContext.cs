using Microsoft.EntityFrameworkCore;

namespace trabalhoLPCTentativaNumero2.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Chamado> Chamados { get; set; }
        public DbSet<Situacao> Situacoes { get; set; }
    }
}