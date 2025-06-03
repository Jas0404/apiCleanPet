using apiCleanPet.Models;

namespace apiCleanPet.Services
{
    public interface ICarrinhoItemService
    {
        Task<List<CarrinhoItem>> GetCarrinho(int usuarioId);
        Task<CarrinhoItem> GetItem(int id);
        Task<CarrinhoItem> Adicionar(CarrinhoItem item);
        Task<bool> Atualizar(CarrinhoItem item);
        Task<bool> Remover(int id);
    }
}
