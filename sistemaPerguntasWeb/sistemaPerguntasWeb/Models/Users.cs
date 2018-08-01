using System.ComponentModel.DataAnnotations;

namespace sistemaPerguntasWeb.Models
{
    public class Users
    {
        public int id { get; set; }
        public string usuario { get; set; }
        public string senha { get; set; }
        public string email { get; set; }
        public string nomeCompleto { get; set; }
        public bool sexo { get; set; }
        public bool termos { get; set; }
    }
}