using System.Collections.Generic;
using trabalhoLPCTentativaNumero2.Models;

namespace trabalhoLPCTentativaNumero2.Interfaces
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