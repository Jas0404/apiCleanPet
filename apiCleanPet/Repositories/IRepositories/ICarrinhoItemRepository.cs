using apiCleanPet.Models;

namespace apiCleanPet.Repositories
{
    public interface ICarrinhoItemRepository
    {
        Task<List<CarrinhoItem>> GetCarrinhoPorUsuario(int usuarioId);
        Task<CarrinhoItem> GetPorId(int id);
        Task<CarrinhoItem> Adicionar(CarrinhoItem item);
        Task<bool> Atualizar(CarrinhoItem item);
        Task<bool> Remover(int id);
        Task<CarrinhoItem> GetPorUsuarioEProduto(int usuarioId, int produtoId);
    }
}
