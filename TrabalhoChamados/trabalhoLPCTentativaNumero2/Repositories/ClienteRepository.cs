using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using trabalhoLPCTentativaNumero2.Interfaces;
using trabalhoLPCTentativaNumero2.Models;

namespace trabalhoLPCTentativaNumero2.Repositories
{
 public class ClienteRepository : IClientesRepository
    {
        private DataContext context;

        public ClienteRepository(DataContext context)
        {
            this.context = context;
        }

        public Cliente GetById(int id)
        {
            return context.Clientes.SingleOrDefault(x => x.id == id);
        }

        public List<Cliente> GetAll()
        {
            return context.Clientes.ToList();
        }

        public void Save(Cliente cliente)
        {
            context.Clientes.Add(cliente);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Clientes.Remove(GetById(id));
            context.SaveChanges();
        }

        public void Update(Cliente cliente)
        {
            context.Entry(cliente).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}