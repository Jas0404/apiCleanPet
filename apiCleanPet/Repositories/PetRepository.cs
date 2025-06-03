using CadastroPetAPI.Models;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace CadastroPetAPI.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly string _connectionString;

        public PetRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task CadastrarPetAsync(Pet pet)
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = @"INSERT INTO castropet (nome, especie, raca, idade, peso, tamanho, cor, pelo, observacoes, imagem)
                          VALUES (@nome, @especie, @raca, @idade, @peso, @tamanho, @cor, @pelo, @observacoes, @imagem)";

            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@nome", pet.Nome);
            command.Parameters.AddWithValue("@especie", pet.Especie);
            command.Parameters.AddWithValue("@raca", pet.Raca);
            command.Parameters.AddWithValue("@idade", pet.Idade);
            command.Parameters.AddWithValue("@peso", pet.Peso);
            command.Parameters.AddWithValue("@tamanho", pet.Tamanho);
            command.Parameters.AddWithValue("@cor", pet.Cor);
            command.Parameters.AddWithValue("@pelo", pet.Pelo);
            command.Parameters.AddWithValue("@observacoes", pet.Observacoes);
            command.Parameters.AddWithValue("@imagem", pet.Imagem);

            await command.ExecuteNonQueryAsync();
        }
    }
}