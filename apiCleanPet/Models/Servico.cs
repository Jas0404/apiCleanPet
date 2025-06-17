using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiCleanPet.Models
{
    [Table("servico")]
    public class Servico
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column("Nome")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Column("Descricao")]
        public string? Descricao { get; set; }

        [Column("Preco", TypeName = "decimal(10,2)")]
        public decimal? Preco { get; set; }

        [Required]
        [Column("imagem")]
        [StringLength(1000)]
        public string Imagem { get; set; }
    }
}
