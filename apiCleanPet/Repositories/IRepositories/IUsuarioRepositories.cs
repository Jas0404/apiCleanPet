public interface IUsuarioRepository
{
    Task<Usuario> BuscarPorEmailAsync(string email);
    Task AtualizarChaveAsync(string email, string chave);
    Task<Usuario> CriarAsync(Usuario dados);
    Task<string> BuscarChaveAcesso(string email);
}
