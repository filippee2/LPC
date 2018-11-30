using System.Collections.Generic;

namespace Chamados.Domain
{
    public interface IClientesRepository
    {
         Cliente GetById(int id);
         List<Cliente> GetAll();
         void Save(Cliente cliente);
         void Delete(int id);
         void Update(Cliente cliente);
    }
}