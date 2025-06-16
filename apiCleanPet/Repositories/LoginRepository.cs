using apiCleanPet.Models;
using apiCleanPet.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace apiCleanPet.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly AppDbContext _context;

        public LoginRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> Autenticar(string login, string senha)
        {
            return await _context.Usuarios
                .Where(u => u.Login == login && u.Senha == senha)
                .FirstOrDefaultAsync();
        }

        public async Task<Usuario> BuscarPorEmail(string email)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> AtualizarUsuario(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();

            var usuarioExists = await _context.Usuarios
                                               .FindAsync(usuario.Id);
            if (usuarioExists == null)
            {
                return false;
            }

            _context.Entry(usuarioExists).CurrentValues.SetValues(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
