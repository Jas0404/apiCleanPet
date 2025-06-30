namespace apiCleanPet.Models
{
    public class CarrinhoItemInput
    {
        public int UsuarioId { get; set; }
        public int ProdutoId { get; set; }
        public int? Quantidade { get; set; } = 1;
    }
}
