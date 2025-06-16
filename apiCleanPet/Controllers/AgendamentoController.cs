using apiCleanPet.Models;
using apiCleanPet.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/agendamentos")]
public class AgendamentoController : ControllerBase
{
    private readonly IAgendamentoService _service;

    public AgendamentoController(IAgendamentoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Agendamento>>> GetAll()
    {
        var agendamentos = await _service.GetAll();
        return Ok(agendamentos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Agendamento>> GetById(int id)
    {
        var agendamento = await _service.GetById(id);
        if (agendamento == null) return NotFound();
        return Ok(agendamento);
    }

    [HttpPost]
    public async Task<ActionResult<Agendamento>> Criar([FromBody] AgendamentoCreateDto dto)
    {
        if (dto == null)
            return BadRequest("Dados do agendamento são obrigatórios.");

        var novoAgendamento = new Agendamento
        {
            IdUsuario = dto.IdUsuario,
            DataHora = dto.DataHora,
            IdStatus = 1 // define o status inicial como 1
        };

        await _service.CriarAsync(novoAgendamento);

        return CreatedAtAction(nameof(GetById), new { id = novoAgendamento.Id }, novoAgendamento);
    }

    [HttpPost("servicos")]
    public async Task<IActionResult> AdicionarServicos([FromBody] AgendamentoServicosDTO dto)
    {
        try
        {
            await _service.AdicionarServicosAsync(dto.AgendamentoId, dto.IdServicos);
            return Ok(new { mensagem = "Serviços adicionados com sucesso!" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }

[HttpPut("{id}")]
    public async Task<ActionResult> Atualizar(int id, Agendamento agendamento)
    {
        if (id != agendamento.Id) return BadRequest();

        var atualizado = await _service.Atualizar(agendamento);
        if (!atualizado) return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Excluir(int id)
    {
        var excluido = await _service.Excluir(id);
        if (!excluido) return NotFound();

        return NoContent();
    }
}