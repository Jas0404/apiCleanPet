using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiCleanPet.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  // Convertido de string para int (recomendado para chave primária em MySQL)

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; } = null!;

        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }

        [Required]
        [MaxLength(500)]
        public string Descricao { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Animal { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Categoria { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Subcategoria { get; set; } = null!;
        //public List<Favorito> Favoritos { get; set; }

        public string imagem { get; set; } = null!;
    }
}