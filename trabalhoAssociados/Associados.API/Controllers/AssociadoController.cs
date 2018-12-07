using System.Collections.Generic;
using System.Threading.Tasks;
using Associados.Domain.AssociadoRoot;
using Associados.Domain.Interaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Associados.API.Controllers
{
    [Route("api/[controller]")]
    public class AssociadoController : Controller
    {
        public readonly IAssociadosRepository _IAssociadoRepository;
        public AssociadoController(IAssociadosRepository iassociadoRepository)
        {
            this._IAssociadoRepository = iassociadoRepository;
        }

        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<AssociadoDTO>> Get()
        {
            return await this._IAssociadoRepository.GetAllDTO();
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<AssociadoDTO> Get(long id)
        {
            return await this._IAssociadoRepository.GetByIdDTO(id);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Associado associado)
        {
            await this._IAssociadoRepository.Add(associado);
            return Ok(new {
                message = "Inserido com sucesso!",
                associado = associado,
            });
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Associado associado)
        {
            await this._IAssociadoRepository.Update(associado);
            return Ok(new {
                message = "Atualização feita com sucesso!",
                associado = associado,
            });
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await this._IAssociadoRepository.Delete(id);
            return Ok(new {
                message = "Deletado com sucesso!",
                id = id,
            });
        }
    }
}