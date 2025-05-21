using apiCleanPet.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace apiCleanPet.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public async Task<Usuario> Post([FromBody] Usuario dados)
        {
            return  await _usuarioService.CadastrarService(dados);
        }
    }
}
