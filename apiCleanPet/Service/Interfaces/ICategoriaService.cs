using apiCleanPet.Models;

namespace apiCleanPet.Services
{
    public interface ICategoriaService
    {
        Task<List<Categoria>> GetAll();
        Task<Categoria?> GetById(int id);
        Task<Categoria> Adicionar(Categoria categoria);
        Task<bool> Atualizar(Categoria categoria);
        Task<bool> Remover(int id);
    }
}
