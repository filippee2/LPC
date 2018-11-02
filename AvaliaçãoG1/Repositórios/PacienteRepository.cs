using System.Collections.Generic;
using System.Linq;
using AvaliaçãoG1.Interfaces;
using AvaliaçãoG1.Models;
using Microsoft.EntityFrameworkCore;

namespace AvaliaçãoG1.Repositórios
{
    public class PacienteRepository : IPacienteRepository
    {
        private DataContext context;
        public PacienteRepository(DataContext context)
        {
            this.context = context;
        }
        public void Delete(int id)
        {
            context.Pacientes.Remove(GetById(id));
            context.SaveChanges();
        }

        public List<Paciente> GetAll()
        {
            return context.Pacientes.Include(i => i.planoSaude).ToList();
        }

        public Paciente GetById(int id)
        {
            return context.Pacientes.SingleOrDefault(x => x.id == id);
        }

        public void Save(Paciente paciente)
        {
            paciente.planoSaude = context.PlanosDeSaude.Find(paciente.planoSaude.id);
            context.Pacientes.Add(paciente);
            context.SaveChanges();
        }

        public void Update(Paciente paciente)
        {
            context.Entry(paciente).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}