using System.ComponentModel.DataAnnotations.Schema;

namespace apiCleanPet.Models
{
    public class LoginUsuario
    {
        public string Login { get; set; }
        public string Senha { get; set; }

    }
}
