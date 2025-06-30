using apiCleanPet.Models;
using Microsoft.EntityFrameworkCore;

namespace apiCleanPet.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Categoria>> GetAllAsync()
        {
            return await _context.Categorias
                .Include(c => c.SubCategorias) // opcional
                .ToListAsync();
        }

        public async Task<Categoria?> GetByIdAsync(int id)
        {
            return await _context.Categorias
                .Include(c => c.SubCategorias)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task CriarAsync(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AtualizarAsync(Categoria categoria)
        {
            if (!await _context.Categorias.AnyAsync(c => c.Id == categoria.Id))
                return false;

            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
                return false;

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
