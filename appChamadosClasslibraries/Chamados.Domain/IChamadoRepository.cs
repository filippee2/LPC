using System.Collections.Generic;

namespace Chamados.Domain
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