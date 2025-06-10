using apiCleanPet.Models;
using apiCleanPet.Services;
using Microsoft.AspNetCore.Mvc;

namespace apiCleanPet.Controllers
{
    [ApiController]
    [Route("api/servicos")]
    public class ServicoController : ControllerBase
    {
        private readonly IServicoService _service;

        public ServicoController(IServicoService service)
        {
            _service = service;
        }

        // GET: api/servico
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Servico>>> GetTodos()
        {
            var servicos = await _service.GetTodos();
            return Ok(servicos);
        }

        // GET: api/servico/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Servico>> GetPorId(int id)
        {
            var servico = await _service.GetPorId(id);
            if (servico == null) return NotFound();
            return Ok(servico);
        }

        // POST: api/servico
        [HttpPost]
        public async Task<ActionResult<Servico>> Post([FromBody] Servico servico)
        {
            var novo = await _service.Adicionar(servico);
            return CreatedAtAction(nameof(GetPorId), new { id = novo.Id }, novo);
        }

        // PUT: api/servico/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Servico servico)
        {
            if (id != servico.Id) return BadRequest();
            var sucesso = await _service.Atualizar(servico);
            if (!sucesso) return NotFound();
            return NoContent();
        }

        // DELETE: api/servico/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sucesso = await _service.Remover(id);
            if (!sucesso) return NotFound();
            return NoContent();
        }
    }
}
