using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Associados.Domain.AssociadoRoot;
using Associados.Domain.Interaces;
using Microsoft.EntityFrameworkCore;

namespace Associados.Repositories.Repositorios
{
    public class AssociadoRepository : IAssociadosRepository
    {
        private DataContext dataContext;
        public AssociadoRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task Add(Associado obj)
        {
            dataContext.Add(obj);
            await dataContext.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            dataContext.Remove(GetById(id));
            await dataContext.SaveChangesAsync();
        }

        public async Task<List<Associado>> GetAll()
        {
            return await dataContext.Associado.Include(i => i.dependentes).ToListAsync();
        }

        public async Task<List<AssociadoDTO>> GetAllDTO()
        {
            return await dataContext.Associado.Include(i => i.dependentes).Select(a =>
                new AssociadoDTO()
                {
                    Id = a.Id,
                    endereco = a.endereco,
                    cidade = a.cidade,
                    uf = a.uf,
                    cep = a.cep,
                    email = a.email,
                }
            ).ToListAsync();
        }

        public async Task<Associado> GetById(long id)
        {
            return await dataContext.Associado.Include(i => i.dependentes).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<AssociadoDTO> GetByIdDTO(long id)
        {
            return await dataContext.Associado.Include(i => i.dependentes).Select(a =>
                new AssociadoDTO()
                {
                    Id = a.Id,
                    endereco = a.endereco,
                    cidade = a.cidade,
                    uf = a.uf,
                    cep = a.cep,
                    email = a.email,
                }
            ).FirstOrDefaultAsync(x => x.Id == id);
        }   

        public async Task Update(Associado obj)
        {
            dataContext.Entry(obj).State = EntityState.Modified;
            await dataContext.SaveChangesAsync();
        }
    }
}