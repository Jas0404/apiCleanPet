using System.ComponentModel.DataAnnotations.Schema;

namespace apiCleanPet.Models
{
    [Table("statusagendamento")]
    public class StatusAgendamento
    {
        public int Id { get; set; }

        [Column("NomeStatus")]
        public string Nome_Status { get; set; } = string.Empty;
    }
}