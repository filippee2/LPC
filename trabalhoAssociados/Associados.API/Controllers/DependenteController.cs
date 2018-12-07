using System.Collections.Generic;
using System.Threading.Tasks;
using Associados.Domain.DependenteRoot;
using Associados.Domain.Interaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Associados.API.Controllers
{
    [Route("api/[controller]")]
    public class DependenteController : Controller
    {
        private readonly IDependentesRepository _IDependenteRepository;
        public DependenteController(IDependentesRepository idependenteRepository)
        {
            this._IDependenteRepository = idependenteRepository;            
        }

        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<Dependente>> Get()
        {
            return await this._IDependenteRepository.GetAll();
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<Dependente> Get(long id)
        {
            return await this._IDependenteRepository.GetById(id);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Dependente dependente)
        {
            await this._IDependenteRepository.Add(dependente);
            return Ok(new {
                message = "Inserido com sucesso!",
                dependente = dependente,
            });
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Dependente dependente)
        {
            await this._IDependenteRepository.Update(dependente);
            return Ok(new {
                message = "Atualização feita com sucesso!",
                dependente = dependente,
            });
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await this._IDependenteRepository.Delete(id);
            return Ok(new {
                message = "Deletado com sucesso!",
                id = id,
            });
        }
    }
}