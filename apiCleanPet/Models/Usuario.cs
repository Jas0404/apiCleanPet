public class Usuario
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Email { get; set; } = null!;
    public string Nome { get; set; } = null!;
    public string CPF { get; set; } = null!;
    public DateTime Nascimento { get; set; }
    public string Celular { get; set; } = null!;
    public string SenhaHash { get; set; } = null!;
    public string? ChaveAcesso { get; set; }
}
