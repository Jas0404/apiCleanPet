using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroPetAPI.Models
{
    [Table("castropet")]
    public class Pet
    {
        public int? Id { get; set; } 
        public string Nome { get; set; }
        public string Especie { get; set; }
        public string Raca { get; set; }
        public int Idade { get; set; }
        public float Peso { get; set; }
        public string Tamanho { get; set; }
        public string Cor { get; set; }
        public string Pelo { get; set; }
        public string? Observacoes { get; set; }
        public string? Imagem { get; set; } // pode ser URL ou base64
    }
}