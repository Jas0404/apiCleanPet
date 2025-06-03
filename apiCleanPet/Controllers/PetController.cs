using Microsoft.AspNetCore.Mvc;
using CadastroPetAPI.Models;
using CadastroPetAPI.Services;

namespace CadastroPetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarPet([FromForm] Pet pet)
        {
            await _petService.CadastrarPetAsync(pet);
            return Ok(new { mensagem = "Pet cadastrado com sucesso!" });
        }
    }
}