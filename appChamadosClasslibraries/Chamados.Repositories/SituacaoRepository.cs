using System.Collections.Generic;
using System.Linq;
using Chamados.Domain;
using Microsoft.EntityFrameworkCore;

namespace Chamados.Repositories
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