public class Usuario
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public DateTime Nascimento { get; set; }
    public string NumCelular { get; set; }
    public string Senha { get; set; }
    public string ChaveAcesso { get; set; } = string.Empty;
    public string Login { get; set; }
    //public List<Favorito> Favoritos { get; set; }
}
