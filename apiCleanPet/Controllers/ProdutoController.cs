using apiCleanPet.Models;
using apiCleanPet.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace apiCleanPet.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoRepository _produtoRepository;

        public ProdutoController(ProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(Produto produto)
        {
            await _produtoRepository.CriarAsync(produto);
            return CreatedAtAction(nameof(ObterPorId), new { id = produto.Id }, produto);
        }

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> ListarTodos()
        {
            var produtos = await _produtoRepository.GetAllAsync();
            return Ok(produtos);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Produto>> ObterPorId(int id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);
            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        [HttpGet("filtro/{animal}/{categoria}/{subcategoria}")]
        public async Task<ActionResult<List<Produto>>> ListarPorCategoria(string animal, string categoria, string subcategoria)
        {
            var produtos = await _produtoRepository.GetPorCategoriaAsync(animal, categoria, subcategoria);
            return Ok(produtos);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Atualizar(int id, Produto produto)
        {
            if (id != produto.Id)
                return BadRequest("ID do produto não confere.");

            var atualizado = await _produtoRepository.AtualizarAsync(produto);
            if (!atualizado)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var excluido = await _produtoRepository.ExcluirAsync(id);
            if (!excluido)
                return NotFound();

            return NoContent();
        }
    }
}
