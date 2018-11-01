using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using trabalhoLPCTentativaNumero2.Interfaces;
using trabalhoLPCTentativaNumero2.Models;

namespace trabalhoLPCTentativaNumero2.Repositories
{
    public class SituacaoRepository : ISituacaoRepository
    {
        private DataContext context;

        public SituacaoRepository(DataContext context)
        {
            this.context = context;
        }

        public Situacao GetById(int id)
        {
            return context.Situacoes.SingleOrDefault(x => x.id == id);
        }

        public List<Situacao> GetAll()
        {
            return context.Situacoes.ToList();
        }

        public void Save(Situacao situacao)
        {
            context.Situacoes.Add(situacao);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Situacoes.Remove(GetById(id));
            context.SaveChanges();
        }

        public void Update(Situacao situacao)
        {
            context.Entry(situacao).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}