using System.Security.Cryptography;
using System.Text;
using apiCleanPet.Service.Interfaces;

namespace apiCleanPet.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Task<string> BuscarChaveAcesso(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> BuscarPorEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> CadastrarService(Usuario dados)
        {
            var senhaHash = CriptografarSenha(dados.Senha);
            dados.Senha = senhaHash;

            return await _usuarioRepository.CriarAsync(dados);
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
    }
}
