using System.Collections.Generic;
using trabalhoLPCTentativaNumero2.Models;

namespace trabalhoLPCTentativaNumero2.Interfaces
{
    public interface IChamadoRepository
    {
        Chamado GetById(int id);
        List<Chamado> GetAll();
        void Save(Chamado chamado);
        void Delete(int id);
        void Update(Chamado chamado);
    }
}