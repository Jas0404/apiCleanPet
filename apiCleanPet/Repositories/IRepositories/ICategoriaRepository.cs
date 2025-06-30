using apiCleanPet.Models;

namespace apiCleanPet.Repositories
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>> GetAllAsync();
        Task<Categoria?> GetByIdAsync(int id);
        Task CriarAsync(Categoria categoria);
        Task<bool> AtualizarAsync(Categoria categoria);
        Task<bool> ExcluirAsync(int id);
    }
}
