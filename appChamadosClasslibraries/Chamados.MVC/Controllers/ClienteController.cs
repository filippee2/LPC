using Chamados.Domain;
using Microsoft.AspNetCore.Mvc;

namespace trabalhoLPCTentativaNumero2.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClientesRepository _repository;
        public ClienteController(IClientesRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var clientes = _repository.GetAll();
            return View(clientes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            _repository.Save(cliente);
            return RedirectToAction("create");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var cliente = _repository.GetById(id);
            return View(cliente);
        }
        [HttpPost]
        public IActionResult Edit(Cliente cliente)
        {
            _repository.Update(cliente);
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("index");
        }
    }
}