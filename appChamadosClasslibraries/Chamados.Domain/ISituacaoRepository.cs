using System.Collections.Generic;

namespace Chamados.Domain
{
    public interface ISituacaoRepository
    {
         Situacao GetById(int id);
         List<Situacao> GetAll();
         void Save(Situacao situacao);
         void Delete(int id);
         void Update(Situacao situacao);

    }
}