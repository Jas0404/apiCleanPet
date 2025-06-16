using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using apiCleanPet.Models;
using apiCleanPet.Repositories.IRepositories;
using apiCleanPet.Service.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
namespace apiCleanPet.Service
{
    public class LoginService : ILoginService
    {
        private readonly JwtTokenConfig _jwtTokenConfig;
        private readonly ILoginRepository _loginRepository;
        private readonly IEmailService _emailService;

        public LoginService(ILoginRepository loginRepository,
                            IEmailService emailService,
                            IOptions<JwtTokenConfig> jwtTokenConfig)
        {
            _loginRepository = loginRepository;
            _emailService = emailService;
            _jwtTokenConfig = jwtTokenConfig.Value;
        }

        public async Task<Usuario> AutenticarService(string login, string senha)
        {
            var senhaHash = CriptografarSenha(senha);
            return await _loginRepository.Autenticar(login, senhaHash);
        }

        public string CriptografarSenha(string senha)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(senha);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        public async Task<Usuario> BuscarPorEmailService(string email)
        {
            return await _loginRepository.BuscarPorEmail(email);
        }

        public async Task<bool> EnviarChaveAcessoPorEmail(string email)
        {
            var usuario = await _loginRepository.BuscarPorEmail(email);
            if (usuario == null) return false;

            var chave = new Random().Next(100000, 999999).ToString();
            usuario.ChaveAcesso = chave;

            await _loginRepository.AtualizarUsuario(usuario);

            string assunto = "Sua chave de acesso";
            string corpo = $"Olá! Sua chave de acesso é: {chave}.";

            await _emailService.EnviarEmailAsync(email, assunto, corpo);

            return true;
        }

        public string GerarToken(Usuario dadosLogin)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,dadosLogin.Nome),
                new Claim(ClaimTypes.Email,dadosLogin.Email),
                new Claim(ClaimTypes.NameIdentifier,
                                        dadosLogin.Id.ToString())
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtTokenConfig.SecretKey));

            var cred = new SigningCredentials(key,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtTokenConfig.Issuer,
                audience: _jwtTokenConfig.Audience,
                claims: claims,
                signingCredentials: cred,
                expires: DateTime.UtcNow.AddHours(5)
                );

            return new JwtSecurityTokenHandler()
                                .WriteToken(token);
        }
    }
}