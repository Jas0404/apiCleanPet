using apiCleanPet.Models;
using apiCleanPet.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apiCleanPet.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(Produto produto)
        {
            await _produtoService.Adicionar(produto);
            return CreatedAtAction(nameof(ObterPorId), new { id = produto.Id }, produto);
        }

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> ListarTodos()
        {
            var produtos = await _produtoService.GetAll();
            return Ok(produtos);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Produto>> ObterPorId(int id)
        {
            var produto = await _produtoService.GetById(id);
            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        [HttpGet("filtro/{animal}/{categoria}/{subcategoria}")]
        public async Task<ActionResult<List<Produto>>> ListarPorCategoria(string animal, string categoria, string subcategoria)
        {
            var produtos = await _produtoService.GetPorCategoria(animal, categoria, subcategoria);
            return Ok(produtos);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Atualizar(int id, Produto produto)
        {
            if (id != produto.Id)
                return BadRequest("ID do produto não confere.");

            var atualizado = await _produtoService.Atualizar(produto);
            if (!atualizado)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var excluido = await _produtoService.Remover(id);
            if (!excluido)
                return NotFound();

            return NoContent();
        }

        [HttpGet("buscar/{nome}")]
        public async Task<ActionResult<List<Produto>>> BuscarPorNome(string nome)
        {
            var produtos = await _produtoService.BuscarPorNome(nome);
            if (produtos == null || produtos.Count == 0)
                return NotFound();

            return Ok(produtos);
        }
    }
}
