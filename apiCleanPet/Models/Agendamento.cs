using System.ComponentModel.DataAnnotations.Schema;
using apiCleanPet.Models;

namespace apiCleanPet.Models
{
    [Table("agendamento")]
    public class Agendamento
    {
        public int Id { get; set; }

        [Column("dataHora")]
        public DateTime DataHora { get; set; }

        [Column("idStatus")]
        public int IdStatus { get; set; }

        [Column("idUsuario")]
        public int IdUsuario { get; set; }

        [ForeignKey("IdStatus")]
        public StatusAgendamento? Status { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario? Usuario { get; set; }

        public List<AgendamentoServico>? Servicos { get; set; }
    }
}