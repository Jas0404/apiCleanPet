namespace apiCleanPet.Models
{
    public class AgendamentoServicosDTO
    {
        public int AgendamentoId { get; set; }
        public List<int> IdServicos { get; set; } = new();
    }
}
