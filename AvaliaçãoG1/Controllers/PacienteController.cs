using AvaliaçãoG1.Interfaces;
using AvaliaçãoG1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AvaliaçãoG1.Controllers
{
    public class PacienteController : Controller
    {
        private readonly IPacienteRepository _repositoryPaciente;
        private readonly IPlanoDeSaudeRepository _repositoryPlanoDeSaude;

        public PacienteController(IPacienteRepository repositoryPaciente, IPlanoDeSaudeRepository repositoryPlanoDeSaude)
        {
            _repositoryPaciente = repositoryPaciente;
            _repositoryPlanoDeSaude = repositoryPlanoDeSaude;
        }

        public IActionResult Index()
        {
            var pacientes = _repositoryPaciente.GetAll();
            return View(pacientes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.planos = _repositoryPlanoDeSaude.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Paciente paciente)
        {
            _repositoryPaciente.Save(paciente);
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.planos = _repositoryPlanoDeSaude.GetAll();
            var paciente = _repositoryPaciente.GetById(id);
            return View(paciente);
        }

        [HttpPost]
        public IActionResult Edit(Paciente paciente)
        {   
            _repositoryPaciente.Update(paciente);
            return RedirectToAction("index");
        }
        
        public IActionResult Delete(int id)
        {
            _repositoryPaciente.Delete(id);
            return RedirectToAction("index");
        }
        
    }
}