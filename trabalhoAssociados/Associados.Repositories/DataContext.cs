using Associados.Domain.AssociadoRoot;
using Associados.Domain.DependenteRoot;
using Associados.Domain.UsarioRoot;
using Microsoft.EntityFrameworkCore;

namespace Associados.Repositories
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 

        }

        public DbSet<Associado> Associado { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Dependente> Dependente { get; set; }
    }
}