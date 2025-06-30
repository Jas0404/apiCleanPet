using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiCleanPet.Models
{
    public class CarrinhoItem
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }              // ID do usuário dono do item
        public int ProdutoId { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; } = 1;
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

        public decimal Total => PrecoUnitario * Quantidade;

        [ForeignKey("ProdutoId")]
        public Produto Produto { get; set; } = null!;

    }
}
