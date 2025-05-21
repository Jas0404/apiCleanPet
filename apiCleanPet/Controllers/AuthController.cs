//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;
//using CleanPet.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;

//[ApiController]
//[Route("api/usuarios")]
//public class AuthController : ControllerBase
//{

//    [HttpPost("criar")]
//    public async Task<IActionResult> Cadastrar([FromBody] CadastroRequest request)
//    {
//        var usuarioExistente = await _usuarioRepository.BuscarPorEmailAsync(request.Email);
//        if (usuarioExistente != null)
//            return Conflict(new { mensagem = "E-mail já cadastrado." });

//        var usuario = new Usuario
//        {
//            Email = request.Email,
//            Nome = request.Nome,
//            CPF = request.CPF,
//            Nascimento = request.Nascimento,
//            Celular = request.Celular,
//            SenhaHash = request.Senha
//        };

//        await _usuarioRepository.CriarAsync(usuario);

//        var chave = new Random().Next(100000, 999999).ToString();

//        await _usuarioRepository.AtualizarChaveAsync(usuario.Email, chave);

//        await _emailService.EnviarAsync(usuario.Email, "Sua chave de acesso", $"Sua chave é: {chave}");

//        return Ok(new { mensagem = "Usuário cadastrado. Verifique seu e-mail para a chave de acesso." });
//    }

//    [HttpPost("login-chave")]
//    public async Task<IActionResult> LoginComChave([FromBody] LoginChaveRequest request)
//    {
//        var usuario = await _usuarioRepository.BuscarPorEmailAsync(request.Email);

//        if (usuario == null)
//            return NotFound(new { mensagem = "E-mail não encontrado." });

//        var token = GerarTokenJWT(usuario);

//        var chaveAcesso = await _usuarioRepository.BuscarChaveAcesso(usuario.Email);

//        return Ok(new { chaveAcesso });
//    }

//    private string GerarTokenJWT(Usuario usuario)
//    {
//        var claims = new[]
//        {
//            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
//            new Claim(ClaimTypes.Name, usuario.Nome),
//            new Claim(ClaimTypes.Email, usuario.Email)
//        };

//        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ChaveSecretaJWT));
//        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//        var token = new JwtSecurityToken(
//            issuer: "CleanPetAPI",
//            audience: "CleanPetAPI",
//            claims: claims,
//            expires: DateTime.UtcNow.AddHours(1),
//            signingCredentials: creds
//        );

//        return new JwtSecurityTokenHandler().WriteToken(token);
//    }
//}
