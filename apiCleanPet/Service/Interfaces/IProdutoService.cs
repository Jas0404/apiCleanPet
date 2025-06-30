using apiCleanPet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apiCleanPet.Services
{
    public interface IProdutoService
    {
        Task<List<Produto>> GetAll();
        Task<Produto?> GetById(int id);
        Task<List<Produto>> GetPorCategoria(string categoria);
        Task<List<Produto>> GetPorSubCategoria(string categoria, string subcategoria);
        Task<Produto> Adicionar(Produto produto);
        Task<bool> Atualizar(Produto produto);
        Task<bool> Remover(int id);
        Task<List<Produto>> BuscarPorNome(string nome);

    }
}
