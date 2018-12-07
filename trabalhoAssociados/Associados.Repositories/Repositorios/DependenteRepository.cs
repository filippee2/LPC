using System.Collections.Generic;
using System.Threading.Tasks;
using Associados.Domain.DependenteRoot;
using Associados.Domain.Interaces;
using Microsoft.EntityFrameworkCore;

namespace Associados.Repositories.Repositorios
{
    public class DependenteRepository : IDependentesRepository
    {
        private DataContext dataContext;
        public DependenteRepository(DataContext dataContext)
        {           
            this.dataContext = dataContext;
        }
        public async Task Add(Dependente obj)
        {
            dataContext.Entry(obj);
            await dataContext.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            dataContext.Remove(GetById(id));
            await dataContext.SaveChangesAsync();
        }

        public async Task<List<Dependente>> GetAll()
        {
            return await dataContext.Dependente.ToListAsync();
        }

        public async Task<Dependente> GetById(long id)
        {
            return await dataContext.Dependente.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Dependente obj)
        {
            dataContext.Entry(obj).State = EntityState.Modified;
            await dataContext.SaveChangesAsync();
        }
    }
}