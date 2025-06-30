using apiCleanPet.Models;
using apiCleanPet.Services;
using Microsoft.AspNetCore.Mvc;

namespace apiCarrinho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarrinhoItemController : ControllerBase
    {
        private readonly ICarrinhoItemService _service;

        public CarrinhoItemController(ICarrinhoItemService service)
        {
            _service = service;
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<ActionResult<IEnumerable<CarrinhoItem>>> GetCarrinho(int usuarioId)
        {
            var itens = await _service.GetCarrinho(usuarioId);
            return Ok(itens);
        }

        [HttpGet("item/{id}")]
        public async Task<ActionResult<CarrinhoItem>> GetItem(int id)
        {
            var item = await _service.GetItem(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<CarrinhoItem>> Post([FromBody] CarrinhoItem item)
        {
            var novo = await _service.Adicionar(item);
            return CreatedAtAction(nameof(GetItem), new { id = novo.Id }, novo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CarrinhoItem item)
        {
            if (id != item.Id) return BadRequest();
            var sucesso = await _service.Atualizar(item);
            if (!sucesso) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sucesso = await _service.Remover(id);
            if (!sucesso) return NotFound();
            return NoContent();
        }
    }
}
