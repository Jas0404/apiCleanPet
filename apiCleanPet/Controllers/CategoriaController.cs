using apiCleanPet.Models;
using apiCleanPet.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apiCleanPet.Controllers
{
    [ApiController]
    [Route("api/categorias")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(Categoria categoria)
        {
            await _categoriaService.Adicionar(categoria);
            return CreatedAtAction(nameof(ObterPorId), new { id = categoria.Id }, categoria);
        }

        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> ListarTodas()
        {
            var categorias = await _categoriaService.GetAll();
            return Ok(categorias);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Categoria>> ObterPorId(int id)
        {
            var categoria = await _categoriaService.GetById(id);
            if (categoria == null)
                return NotFound();

            return Ok(categoria);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Atualizar(int id, Categoria categoria)
        {
            if (id != categoria.Id)
                return BadRequest("ID da categoria não confere.");

            var atualizado = await _categoriaService.Atualizar(categoria);
            if (!atualizado)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var excluido = await _categoriaService.Remover(id);
            if (!excluido)
                return NotFound();

            return NoContent();
        }
    }
}
