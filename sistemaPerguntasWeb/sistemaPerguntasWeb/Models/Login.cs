using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace sistemaPerguntasWeb.Models
{
    public class Login
    {
        [Required]
        public string Usuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [HiddenInput]
        public string ReturnUrl { get; set; }
    }
}