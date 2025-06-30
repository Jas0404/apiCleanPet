using apiCleanPet.Models;
using apiCleanPet.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace apiCleanPet.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

       
        [HttpPost("autenticar")]
        public async Task<ActionResult> Autenticar([FromBody] LoginRequest dados)
        {
            var usuario = await _loginService.AutenticarService(dados.Login, dados.Senha);
            if (usuario == null)
            {
                return Unauthorized(new { msg = "Login ou Senha inválidos!" });
            }

            var token = _loginService.GerarToken(usuario);

            return Ok(new
            {
                token = token,
                id = usuario.Id,
                login = usuario.Login
            });
        }

        [HttpPost("chave-acesso/solicitar")]
        public async Task<ActionResult> AutenticarViaChave([FromBody] LoginChaveRequest dados)
        {
            var usuario = await _loginService.BuscarPorEmailService(dados.Email);
            if (usuario == null)
            {
                return Unauthorized(new { msg = "E-mail informado não possui cadastro!" });
            }

            var enviaChaveAcesso = await _loginService.EnviarChaveAcessoPorEmail(dados.Email);

            var token = _loginService.GerarToken(usuario);

            return Ok(new
            {
                Token = token,
                Login = usuario.Login
            });
        }
    }
}
