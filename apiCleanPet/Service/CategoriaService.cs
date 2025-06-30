using apiCleanPet.Models;
using apiCleanPet.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apiCleanPet.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Categoria>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Categoria?> GetById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Categoria> Adicionar(Categoria categoria)
        {
            await _repository.CriarAsync(categoria);
            return categoria;
        }

        public async Task<bool> Atualizar(Categoria categoria)
        {
            return await _repository.AtualizarAsync(categoria);
        }

        public async Task<bool> Remover(int id)
        {
            return await _repository.ExcluirAsync(id);
        }
    }
}
