using apiCleanPet;
using Microsoft.EntityFrameworkCore;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;

    public UsuarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Usuario> BuscarPorEmail(string email)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
    }


    public async Task<Usuario> CriarAsync(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }

    public Task AtualizarChaveAsync(string email, string chave)
    {
        var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == email);
        if (usuario != null)
            usuario.ChaveAcesso = chave;
        return Task.CompletedTask;
    }


    public async Task<string> BuscarChaveAcesso(string email)
    {
        var dados = _context.Usuarios.FirstOrDefault(u => u.Email == email);
        return dados.ChaveAcesso;
    }
}
