using AvaliaçãoG1.Interfaces;
using AvaliaçãoG1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AvaliaçãoG1.Controllers
{
    public class PlanoDeSaudeController : Controller
    {
        private readonly IPlanoDeSaudeRepository _repositoryPlanoDeSaude;

        public PlanoDeSaudeController(IPlanoDeSaudeRepository repositoryPlanodeSaude)
        {
            _repositoryPlanoDeSaude = repositoryPlanodeSaude;
        }

        public IActionResult Index()
        {
            var planos = _repositoryPlanoDeSaude.GetAll();
            return View(planos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PlanoDeSaude planoDeSaude)
        {
            _repositoryPlanoDeSaude.Save(planoDeSaude);
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var planoDeSaude = _repositoryPlanoDeSaude.GetById(id);
            return View(planoDeSaude);
        }

        [HttpPost]
        public IActionResult Edit(PlanoDeSaude planoDeSaude)
        {
            _repositoryPlanoDeSaude.Update(planoDeSaude);
            return RedirectToAction("index");
        }
        
        public IActionResult Delete(int id)
        {
            _repositoryPlanoDeSaude.Delete(id);
            return RedirectToAction("index");
        }
    }
}