using System.Collections.Generic;
using trabalhoLPCTentativaNumero2.Models;

namespace trabalhoLPCTentativaNumero2.Interfaces
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