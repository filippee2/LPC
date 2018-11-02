using System.Collections.Generic;
using AvaliaçãoG1.Models;

namespace AvaliaçãoG1.Interfaces
{
    public interface IPlanoDeSaudeRepository
    {
        PlanoDeSaude GetById(int id);
        List<PlanoDeSaude> GetAll();
        void Save(PlanoDeSaude planoDeSaude);
        void Delete(int id);
        void Update(PlanoDeSaude planoDeSaude);
    }
}