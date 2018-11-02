using System;
using System.Collections.Generic;
using AvaliaçãoG1.Models;

namespace AvaliaçãoG1.Interfaces
{
    public interface IConsultaRepository
    {   
        Consulta GetById(int id);
        List<Consulta> GetAll();
        void Save(Consulta consulta);
        void Delete(int id);
        void Update(Consulta consulta);
        List<Consulta> Search(DateTime data);
    }
}