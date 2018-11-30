using Chamados.Domain;
using Microsoft.AspNetCore.Mvc;

namespace trabalhoLPCTentativaNumero2.Controllers
{
    public class SituacaoController : Controller
    {
        private readonly ISituacaoRepository _repositorySituacao;

        public SituacaoController(ISituacaoRepository repositorySituacao)
        {
            _repositorySituacao = repositorySituacao;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Situacao situacao)
        {
            _repositorySituacao.Save(situacao);
            return RedirectToAction("create");
        }

        public IActionResult Index()
        {
            var situacoes = _repositorySituacao.GetAll();
            return View(situacoes);
        }

        public IActionResult Delete(int id)
        {
            _repositorySituacao.Delete(id);
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var situacao = _repositorySituacao.GetById(id);
            return View(situacao);
        }
        [HttpPost]
        public IActionResult Edit(Situacao situacao)
        {
            _repositorySituacao.Update(situacao);
            return RedirectToAction("index");
        }
    }
}