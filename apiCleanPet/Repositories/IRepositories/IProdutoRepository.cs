using apiCleanPet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apiCleanPet.Repositories
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> GetAllAsync();
        Task<Produto?> GetByIdAsync(int id);
        Task<List<Produto>> GetPorCategoriaAsync(string animal, string categoria, string subcategoria);
        Task CriarAsync(Produto produto);
        Task<bool> AtualizarAsync(Produto produto);
        Task<bool> ExcluirAsync(int id);
        Task<List<Produto>> BuscarPorNome(string nome);
    }
}
