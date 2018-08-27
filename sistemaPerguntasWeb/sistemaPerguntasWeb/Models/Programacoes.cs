using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistemaPerguntasWeb.Models
{
    public class Programacoes
    {
        public Programacoes(string _titulo)
        {
            Titulo = _titulo;
        }
        public int IDProgramacao { get; set; }
        public DateTimeKind Data { get; set; }
        public string Titulo { get; set; }
        public string Corpo { get; set; }
        public string Fonte { get; set; }
    }
}