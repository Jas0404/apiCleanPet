using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using apiCleanPet.Models;

[Table("sub_categoria")]
public class SubCategoria
{
    [Key]
    [Column("id_sub_categoriai")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [Column("nome_sub_categoria")]
    [MaxLength(150)]
    public string Nome { get; set; } = null!;

    [Required]
    [Column("id_categoria")]
    public int CategoriaId { get; set; }

    [ForeignKey("CategoriaId")]
    [JsonIgnore] // <- isso aqui evita o ciclo!
    public Categoria? Categoria { get; set; }
}
