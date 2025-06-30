using apiCleanPet.Models;
using apiCleanPet.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apiCleanPet.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Produto>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Produto?> GetById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<Produto>> GetPorCategoria(string categoria)
        {
            return await _repository.GetPorCategoriaAsync(categoria);
        }

        public async Task<List<Produto>> GetPorSubCategoria( string categoria, string subcategoria)
        {
            return await _repository.GetPorSubCategoriaAsync( categoria, subcategoria);
        }

        public async Task<Produto> Adicionar(Produto produto)
        {
            await _repository.CriarAsync(produto);
            return produto;
        }

        public async Task<bool> Atualizar(Produto produto)
        {
            return await _repository.AtualizarAsync(produto);
        }

        public async Task<bool> Remover(int id)
        {
            return await _repository.ExcluirAsync(id);
        }

        public async Task<List<Produto>> BuscarPorNome(string nome)
        {
            return await _repository.BuscarPorNome(nome);
        }
    }
}
