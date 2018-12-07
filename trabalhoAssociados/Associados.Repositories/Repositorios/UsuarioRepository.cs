using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Associados.Domain.Interaces;
using Associados.Domain.UsarioRoot;
using Microsoft.EntityFrameworkCore;

namespace Associados.Repositories.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private DataContext dataContext;
        public UsuarioRepository (DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task Add(Usuario obj)
        {
            dataContext.Add(obj);
            await dataContext.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            dataContext.Remove(GetById(id));
            await dataContext.SaveChangesAsync();
        }

        public async Task<List<Usuario>> GetAll()
        {
            return await dataContext.Usuario.ToListAsync();
        }

        public async Task<Usuario> GetById(long id)
        {
            return await dataContext.Usuario.SingleOrDefaultAsync();
        }

        public async Task Update(Usuario obj)
        {
            dataContext.Entry(obj).State = EntityState.Modified;
            await dataContext.SaveChangesAsync();
        }

        public Usuario AuthUsuario(Usuario usuario) 
        {
            return dataContext
            .Usuario
            .SingleOrDefault(i => i.login == usuario.login && i.senha == usuario.senha);
        }
    }
}