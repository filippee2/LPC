using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using trabalhoLPCTentativaNumero2.Interfaces;
using trabalhoLPCTentativaNumero2.Models;

namespace trabalhoLPCTentativaNumero2.Repositories
{
    public class ChamadoRepository : IChamadoRepository
    {
        private DataContext context;

        public ChamadoRepository(DataContext context)
        {
            this.context = context;
        }

        public Chamado GetById(int id)
        {
            return context.Chamados.SingleOrDefault(x=>x.id == id);
        }

        public List<Chamado> GetAll()
        {
            return context.Chamados.Include(i => i.cliente).Include(x => x.situacao).ToList();
        }

        public void Save(Chamado chamado)
        {
            if (chamado.horaFim != null)
            {
                chamado.tempoDuracao = chamado.horaFim.Value - chamado.horaInicio;
            }
            chamado.cliente = context.Clientes.Find(chamado.cliente.id);
            chamado.situacao = context.Situacoes.Find(chamado.situacao.id);
            context.Chamados.Add(chamado);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Chamados.Remove(GetById(id));
            context.SaveChanges();
        }

        public void Update(Chamado chamado)
        {
            if (chamado.horaFim != null)
            {
                chamado.tempoDuracao = chamado.horaFim.Value - chamado.horaInicio;
            }
            context.Entry(chamado).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}