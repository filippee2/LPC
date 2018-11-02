using System.Collections.Generic;
using System.Linq;
using AvaliaçãoG1.Interfaces;
using AvaliaçãoG1.Models;
using Microsoft.EntityFrameworkCore;

namespace AvaliaçãoG1.Repositórios
{
    public class PlanoDeSaudeRepository : IPlanoDeSaudeRepository
    {
        private DataContext context;
        public PlanoDeSaudeRepository(DataContext context)
        {
            this.context = context;
        }
        public void Delete(int id)
        {
            context.PlanosDeSaude.Remove(GetById(id));
            context.SaveChanges();
        }

        public List<PlanoDeSaude> GetAll()
        {
            return context.PlanosDeSaude.ToList();
        }

        public PlanoDeSaude GetById(int id)
        {
            return context.PlanosDeSaude.SingleOrDefault(x => x.id == id);
        }

        public void Save(PlanoDeSaude planoDeSaude)
        {
            context.PlanosDeSaude.Add(planoDeSaude);
            context.SaveChanges();
        }

        public void Update(PlanoDeSaude planoDeSaude)
        {
            context.Entry(planoDeSaude).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}