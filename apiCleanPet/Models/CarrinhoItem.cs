using System;

namespace apiCleanPet.Models
{
    public class CarrinhoItem
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }              // ID do usuário dono do item
        public int ProdutoId { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; } = 1;
        public string Imagem { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

        public decimal Total => PrecoUnitario * Quantidade;

    }
}
