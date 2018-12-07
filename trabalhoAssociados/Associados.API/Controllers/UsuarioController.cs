using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using Associados.Domain.Interaces;
using Associados.Domain.UsarioRoot;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Associados.API.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        public readonly IUsuarioRepository _IUsuarioRepository;
        public UsuarioController(IUsuarioRepository iusuarioRepository)
        {
            this._IUsuarioRepository = iusuarioRepository;
        }

        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<Usuario>> Get()
        {
            return await this._IUsuarioRepository.GetAll();
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<Usuario> Get(long id)
        {
            return await this._IUsuarioRepository.GetById(id);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Usuario usuario)
        {
            await this._IUsuarioRepository.Add(usuario);
            return Ok(new
            {
                message = "Inserido com sucesso!",
                usuario = usuario,
            });
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Usuario usuario)
        {
            await this._IUsuarioRepository.Update(usuario);
            return Ok(new
            {
                message = "Atualização feita com sucesso!",
                usuario = usuario,
            });
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await this._IUsuarioRepository.Delete(id);
            return Ok(new
            {
                message = "Deletado com sucesso!",
                id = id,
            });
        }

        [HttpPost("authenticate")]
        public IActionResult Authentication([FromBody] Usuario user)
        {
            var usuario = this._IUsuarioRepository.AuthUsuario(user);

            if (usuario == null)
                return BadRequest(new
                {
                    message = "Login e/ou senha incorreto(s)."
                });

            return Ok(new
            {
                token = BuildToken()
            });
        }

        public string BuildToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Aula15UlbraTorres"));

            var creed = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                audience: "Aula18",
                issuer: "Aula18",
                signingCredentials: creed
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}