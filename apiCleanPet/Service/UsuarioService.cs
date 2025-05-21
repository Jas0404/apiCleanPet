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
            return await _usuarioRepository.CriarAsync(dados);
        }
    }
}
