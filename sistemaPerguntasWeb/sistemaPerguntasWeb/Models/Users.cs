using System.ComponentModel.DataAnnotations;

namespace sistemaPerguntasWeb.Models
{
    public class Users
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string usuario { get; set; }
        [Required]
        public string senha { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string nomeCompleto { get; set; }
        [Required]
        public bool sexo { get; set; }
        [Required]
        public bool termos { get; set; }

        private int _id;
        private string _usuario;
        private string _senha;
        private string _email;
        private string _nomeCompleto;
        private bool _sexo;
        private bool _termos;

        public Users()
        {
            //id = _id;
            usuario = _usuario;
            senha = _senha;
            email = _email;
            nomeCompleto = _nomeCompleto;
            sexo = _sexo;
            termos = _termos;
        }
    }
}