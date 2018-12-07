using System.Collections.Generic;
using System.Threading.Tasks;

namespace Associados.Domain.Interaces
{
    public interface IRepositoryBase<Entity> where Entity : class
    {
         Task<Entity> GetById(long id);
         Task<List<Entity>> GetAll();
         Task Delete(long id);
         Task Update(Entity obj);
         Task Add(Entity obj);
    }
}