using System;
using System.Collections.Generic;
using System.Linq;
using AvaliaçãoG1.Interfaces;
using AvaliaçãoG1.Models;
using Microsoft.EntityFrameworkCore;

namespace AvaliaçãoG1.Repositórios
{
    public class ConsultaRepository : IConsultaRepository
    {
        private DataContext context;

        public ConsultaRepository(DataContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            context.Consultas.Remove(GetById(id));
            context.SaveChanges();
        }

        public List<Consulta> GetAll()
        {
            return context.Consultas.Include(i => i.paciente).ToList();
        }

        public Consulta GetById(int id)
        {
            return context.Consultas.SingleOrDefault(x => x.id == id);
        }

        public void Save(Consulta consulta)
        {
            consulta.paciente = context.Pacientes.Find(consulta.paciente.id);
            context.Consultas.Add(consulta);
            context.SaveChanges();
        }

        public void Update(Consulta consulta)
        {
            context.Entry(consulta).State = EntityState.Modified;
            context.SaveChanges();
        }

        public List<Consulta> Search(DateTime data)
        {
            return context.Consultas.Include(consulta => consulta.paciente).Where(consulta => consulta.data == data).ToList();
        }
    }
}