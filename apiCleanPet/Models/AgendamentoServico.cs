using System.ComponentModel.DataAnnotations.Schema;

namespace apiCleanPet.Models
{
    [Table("agendamentoservico")]
    public class AgendamentoServico
    {
        public int Id { get; set; }
        public int AgendamentoId { get; set; }
        public int ServicoId { get; set; }

        // Navegação (opcional)
        public Servico? Servico { get; set; }
    }
}
