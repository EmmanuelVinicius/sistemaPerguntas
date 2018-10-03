using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistemaPerguntasWeb.Models
{
    public class Alunos:Users
    {
        public DateTime DataInscricao { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public int Idade { get; set; }
        public int Etapa { get; set; }
    }
}