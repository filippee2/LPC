using System;
using AvaliaçãoG1.Interfaces;
using AvaliaçãoG1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AvaliaçãoG1.Controllers
{
    public class ConsultaController : Controller
    {
        private readonly IConsultaRepository _repositoryConsulta;
        private readonly IPacienteRepository _repositoryPaciente;
        public ConsultaController(IConsultaRepository repositoryConsulta, IPacienteRepository repositoryPaciente)
        {
            _repositoryConsulta = repositoryConsulta;
            _repositoryPaciente = repositoryPaciente;
        }

        public IActionResult Index()
        {
            var consultas = _repositoryConsulta.GetAll();
            return View(consultas); 
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.pacientes = _repositoryPaciente.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Consulta consulta)
        {
            _repositoryConsulta.Save(consulta);
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.pacientes = _repositoryPaciente.GetAll();
            var consulta = _repositoryConsulta.GetById(id);
            return View(consulta);
        }
        [HttpPost]
        public IActionResult Edit(Consulta consulta)
        {
            _repositoryConsulta.Update(consulta);
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            _repositoryConsulta.Delete(id);
            return RedirectToAction("index");
        }
        [HttpPost]
        public IActionResult Index(DateTime searchData)
        {
            var consultas = _repositoryConsulta.Search(searchData);
            return View(consultas);
        }
    }
}