using System.Linq;
using Microsoft.AspNetCore.Mvc;
using trabalhoLPCTentativaNumero2.Interfaces;
using trabalhoLPCTentativaNumero2.Models;

namespace trabalhoLPCTentativaNumero2.Controllers
{
    public class ChamadoController : Controller
    {
        private readonly IChamadoRepository _repositoryChamado;
        private readonly IClientesRepository _repositoryCliente;
        private readonly ISituacaoRepository _repositorySituacoes;
        public ChamadoController(IChamadoRepository repositoryChamado, IClientesRepository repositoryCliente, ISituacaoRepository repositorySituacoes)
        {
            _repositoryCliente = repositoryCliente;
            _repositoryChamado = repositoryChamado;
            _repositorySituacoes = repositorySituacoes;
        }
        public IActionResult Index()
        {
            var chamados = _repositoryChamado.GetAll().OrderByDescending(x => x.data);
            return View(chamados);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.clientes = _repositoryCliente.GetAll();
            ViewBag.situacoes = _repositorySituacoes.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Chamado chamado)
        {
            _repositoryChamado.Save(chamado);
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.situacoes = _repositorySituacoes.GetAll();
            ViewBag.clientes = _repositoryCliente.GetAll();
            var chamado = _repositoryChamado.GetById(id);
            return View(chamado);
        }
        [HttpPost]
        public IActionResult Edit(Chamado chamado)
        {
            _repositoryChamado.Update(chamado);
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            _repositoryChamado.Delete(id);
            return RedirectToAction("index");
        }
    }
}