namespace apiCleanPet.Service.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> CadastrarService(Usuario usuario);
        Task<Usuario> BuscarPorEmail(string email);
        Task<string> BuscarChaveAcesso(string email);
    }
}
