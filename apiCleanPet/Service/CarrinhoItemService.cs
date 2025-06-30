using apiCleanPet.Models;
using apiCleanPet.Repositories;
using apiCleanPet.Services;

namespace apiCleanPet.Services
{
    public class CarrinhoItemService : ICarrinhoItemService
    {
        private readonly ICarrinhoItemRepository _repository;
        private readonly IProdutoService _produtoService;

        public CarrinhoItemService(ICarrinhoItemRepository repository, IProdutoService produtoService)
        {
            _repository = repository;
            _produtoService = produtoService;
        }

        public async Task<List<CarrinhoItem>> GetCarrinho(int usuarioId)
        {
            return await _repository.GetCarrinhoPorUsuario(usuarioId);
        }

        public async Task<CarrinhoItem> GetItem(int id)
        {
            return await _repository.GetPorId(id);
        }

        public async Task<CarrinhoItem> Adicionar(CarrinhoItem item)
        {
            var dadosProduto = _produtoService.GetById(item.ProdutoId);

            if (dadosProduto == null)
            {
                throw new Exception("Produto não encontrado.");
            }

            if(item.Quantidade < 1)
            {
                item.Quantidade = 1;
            }

            item.PrecoUnitario = dadosProduto.Result.Preco;

            // Verifica se já existe o produto no carrinho do mesmo usuário
            var itemExistente = await _repository.GetPorUsuarioEProduto(item.UsuarioId, item.ProdutoId);

            if (itemExistente != null)
            {
                // Atualiza a quantidade existente
                itemExistente.Quantidade += item.Quantidade;
                await _repository.Atualizar(itemExistente);
                return itemExistente;
            }

            return await _repository.Adicionar(item);
        }

        public async Task<bool> Atualizar(CarrinhoItem item)
        {
            return await _repository.Atualizar(item);
        }

        public async Task<bool> Remover(int id)
        {
            return await _repository.Remover(id);
        }
    }
}
