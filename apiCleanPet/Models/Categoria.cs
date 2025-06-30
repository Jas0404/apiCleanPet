using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiCleanPet.Models
{
    [Table("categoria")]
    public class Categoria
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("nome")]
        [MaxLength(500)]
        public string Nome { get; set; } = null!;

        public string icone { get; set; } = null!; 
        // Navegação (opcional)
        public ICollection<SubCategoria>? SubCategorias { get; set; }
    }
}
