using System.Collections.Generic;
using AvaliaçãoG1.Models;

namespace AvaliaçãoG1.Interfaces
{
    public interface IPacienteRepository
    {
        Paciente GetById(int id);
        List<Paciente> GetAll();
        void Save(Paciente paciente);
        void Delete(int id);
        void Update(Paciente paciente);
    }
}